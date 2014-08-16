/*
 *  Ares, a multi-player augmented reality first person shooter
 *  Copyright (C) 2009-2010  Jmaxxz, Mike McBride, and Kevin Curtis
 * 
 * This file is under the the following License
 *          DO WHAT THE FUCK YOU WANT TO PUBLIC LICENSE
 *                   Version 2, December 2004
 *       Copyright (C) 2004 Sam Hocevar <sam@hocevar.net>
 *
 *       Everyone is permitted to copy and distribute verbatim or modified
 *       copies of this license document, and changing it is allowed as long
 *       as the name is changed.
 *
 *                  DO WHAT THE FUCK YOU WANT TO PUBLIC LICENSE
 *         TERMS AND CONDITIONS FOR COPYING, DISTRIBUTION AND MODIFICATION
 *
 *          0. You just DO WHAT THE FUCK YOU WANT TO.
 * 
 * 
 * Change log
 * 
 * Version | Author | Reason for change                | Description of change
 * -------- -------- ---------------------------------- ------------------------------------------------------
 * 0.95     mcbridem Initial development                Fully defined every method
 * 0.95     mcbridem Design change                      Changed FindBlobs to Analyze, added players parameter. Added max size and HSB tolerance attributes, edited constructor to accept values for them.
 * 0.95     jmaxxz Code fix, did not run right        Various fixes, preloaded bitmaps to mem, to prevent hdd from holding up feed
 * 1.00     mcbridem Accuracy improvements              Changed algorithm from building a composite filter to multi-pass filtering.
 * 1.0      jmaxxz Misc Refactoring, Server impl      Refactored codebase, added basic server
 * 1.0      jmaxxz Optimization attempt               Merged HSL and GS filters
 * 1.0      jmaxxz Optimization attempt               Merged HSL, GS and Dilation + more parrelization
 * 1.0      mcbridem !LOG MISSING!                      INJECTED COMPILE TIME ERROR, MISSING CHANGE LOG
 * 1.0      jmaxxz Compile time error                 Fixed error by removing blob merging.  Notified mcbridem of error, and that recheck in will be needed.
 * 1.0      mcbridem Compile error                      Reverted merging code to previously committed version.  Compile error resolved; MergedBlob.cs added to repository.
 * 1.0      mcbridem Change to Blob                     Changed blob initialization to match constructor changes in Blob.cs.
 */


namespace Ares.Client.Analysis
{
    using System;
    using AForge;
    using AForge.Imaging;
    using AresAForge;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Linq;
    using Common;


    /// <summary>
    /// This implementation of <see cref="IImageAnalysis"/> finds all of the blobs in the processed images,
    /// based on a rectangular size and HSB tolerances supplied in a constructor, as well as a list of
    /// <see cref="IPlayer"/> objects.
    /// </summary>
    public class BlobDetectionAnalysis : IImageAnalysis
    {
        /// <summary>
        /// Minimum width of a blob to consider.
        /// </summary>
        private readonly int _minBlobWidth = 1;

        /// <summary>
        /// Minimum height of a blob to consider.
        /// </summary>
        private readonly int _minBlobHeight = 1;

        /// <summary>
        /// Maximum width of a blob to consider.
        /// </summary>
        private readonly int _maxBlobWidth = 1;

        /// <summary>
        /// Maximum height of a blob to consider.
        /// </summary>
        private readonly int _maxBlobHeight = 1;

        /// <summary>
        /// Backing field for <see cref="HueTolerance"/>.
        /// </summary>
        private int _hueTolerance;

        /// <summary>
        /// The allowed delta in hue between blob and player color.
        /// </summary>
        public int HueTolerance
        {
            get { return _hueTolerance; }
            set
            {
                if(value < 0 || value > 360)
                    throw new ArgumentOutOfRangeException();
                
                _hueTolerance = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="SaturationTolerance"/>.
        /// </summary>
        private float _saturationTolerance;

        /// <summary>
        /// The allowed delta in saturation between blob and player color.
        /// </summary>
        public float SaturationTolerance
        {
            get { return _saturationTolerance; }
            set
            {
                if (value < 0.0 || value > 1.0)
                    throw new ArgumentOutOfRangeException();

                _saturationTolerance = value;
            }
        }

        /// <summary>
        /// Backing field for <see cref="BrightnessTolerance"/>.
        /// </summary>
        private float _brightnessTolerance;

        /// <summary>
        /// The allowed delta in brightness between blob and player color.
        /// </summary>
        public float BrightnessTolerance
        {
            get { return _brightnessTolerance; }
            set
            {
                if (value < 0.0 || value > 1.0)
                    throw new ArgumentOutOfRangeException();

                _brightnessTolerance = value;
            }
        }

        /// <summary>
        /// This constructor builds a BlobDetectionAnalysis instance.
        /// </summary>
        /// <param name="minBlobWidth">The minimum width of a player's blob.  Pass 1 to ignore when filtering blob sizes.</param>
        /// <param name="minBlobHeight">The minimum height of a player's blob.  Pass 1 to ignore when filtering blob sizes.</param>
        /// <param name="maxBlobWidth">The maximum width of a player's blob.  Pass 1 to ignore when filtering blob sizes.</param>
        /// <param name="maxBlobHeight">The maximum height of a player's blob.  Pass 1 to ignore when filtering blob sizes.</param>
        /// <param name="hueTolerance">The tolerance in hue for the algorithm to detect a player. Hue ranges between 0.0f and 360.0f.</param>
        /// <param name="saturationTolerance">The tolerance in saturation for the algorithm to detect a player. Saturation ranged between 0.0f and 1.0f.</param>
        /// <param name="brightnessTolerance">The tolerance in brightness for the algorithm to detect a player. Brightness ranged between 0.0f and 1.0f.</param>
        public BlobDetectionAnalysis(int minBlobWidth, int minBlobHeight, int maxBlobWidth, int maxBlobHeight, int hueTolerance, float saturationTolerance, float brightnessTolerance)
        {
            if (minBlobWidth > 1)
            {
                _minBlobWidth = minBlobWidth;
            }

            if (minBlobHeight > 1)
            {
                _minBlobHeight = minBlobHeight;
            }

            if (maxBlobWidth > 1)
            {
                _maxBlobWidth = maxBlobWidth;
            }

            if (maxBlobHeight > 1)
            {
                _maxBlobHeight = maxBlobHeight;
            }

            HueTolerance = hueTolerance;
            SaturationTolerance = saturationTolerance;
            BrightnessTolerance = brightnessTolerance;
        }



        /// <summary>
        /// This method scans an Image object for players and returns an <see cref="IProcessedImage"/> object.
        /// </summary>
        /// <param name="image">An image to process for blob objects.</param>
        /// <param name="players">A list of players to scan for.</param>
        /// <returns>An <see cref="IProcessedImage"/> object, which contains the image input and a list of players found.</returns>
        public IProcessedImage Analyze(Bitmap image, IEnumerable<IPlayer> players)
        {
            List<IPlayer>  playerList= players.ToList();
            List<IPlayerBlob> playerBlobs = new List<IPlayerBlob>();
            List<IBlob> allBlobs = new List<IBlob>();

            Bitmap imageTemp = (Bitmap) image.Clone();
            BitmapData objectsData = imageTemp.LockBits(new Rectangle(0, 0, imageTemp.Width, imageTemp.Height), ImageLockMode.ReadOnly, imageTemp.PixelFormat);
            
            // Loop each player
            Parallel.For(0, playerList.Count, delegate(int i)
            {
                SuperHlsFilter hslFilter = new SuperHlsFilter { MultiThreaded = true };

                IntRange hueRange = new IntRange(360, 0);
                DoubleRange satRange = new DoubleRange(1.0, 0.0);
                DoubleRange lumRange = new DoubleRange(1.0, 0.0);

                IPlayer player = playerList[i];
                hueRange.Max = (int)Math.Min(player.ClothingColor.GetHue() + (HueTolerance / 2.0), 360.0);
                hueRange.Min = (int)Math.Max(player.ClothingColor.GetHue() - (HueTolerance / 2.0), 0);

                satRange.Max = Math.Min(player.ClothingColor.GetSaturation() + SaturationTolerance / 2, 1.0);
                satRange.Min = Math.Max(player.ClothingColor.GetSaturation() - SaturationTolerance / 2, 0.0);

                lumRange.Max = Math.Min(player.ClothingColor.GetBrightness() + BrightnessTolerance / 2, 1.0);
                lumRange.Min = Math.Max(player.ClothingColor.GetBrightness() - BrightnessTolerance / 2, 0.0);

                hslFilter.Hue = hueRange;
                hslFilter.Saturation = satRange;
                hslFilter.Luminance = lumRange;

                AForge.Imaging.Blob[] blobs;
                using (UnmanagedImage unmanagedImage = new UnmanagedImage(objectsData))
                {
                    // Apply the filter
                    using (UnmanagedImage gsImage = hslFilter.Apply(unmanagedImage))
                    {
                        // Extracts the array of found blobs from the BlobCounter
                        blobs = FindBlobs(gsImage);
                    }
                }

                // Converts raw blobs into IBlobs
                IList<IBlob> foundBlobs = (from blob in blobs
                                           orderby blob.Area descending
                                           select new Blob(blob, player.ClothingColor)).Cast<IBlob>().ToList();

                IList<IBlob> mergedBlobs = MergeOverlappingBlobs(foundBlobs);
                mergedBlobs = (from blob in mergedBlobs
                               orderby blob.Size descending
                               select blob).ToList();

                IBlob bestBlob = mergedBlobs.FirstOrDefault();

                if (bestBlob != null)
                {
                    lock (playerBlobs)
                    {
                        playerBlobs.Add(new PlayerBlob(bestBlob, player));
                    }

                    lock (allBlobs)
                    {
                        allBlobs.AddRange(mergedBlobs);
                    }
                }
            });

            imageTemp.UnlockBits(objectsData);
            imageTemp.Dispose();


            return new ProcessedImage(image, playerBlobs, allBlobs);
        }

        /// <summary>
        /// Finds the blobs in an image.
        /// </summary>
        /// <param name="image">The image to analyze.</param>
        /// <returns>A list of blobs in the image.</returns>
        public AForge.Imaging.Blob[] FindBlobs(UnmanagedImage image)
        {
            // The BlobCounter object, which does all the heavy lifting
            BlobCounter bc = new BlobCounter();

            // Sets up the blob counter to filter blobs if the size filters are set is set
            if (_minBlobWidth > 1 || _minBlobHeight > 1 || _maxBlobWidth > 1 || _maxBlobHeight > 1)
            {
                bc.FilterBlobs = true;
                if (_minBlobWidth > 1)
                {
                    bc.MinHeight = _minBlobWidth;
                }
                if (_minBlobHeight > 1)
                {
                    bc.MinHeight = _minBlobHeight;
                }
                if (_maxBlobWidth > 1)
                {
                    bc.MaxHeight = _maxBlobWidth;
                }
                if (_maxBlobHeight > 1)
                {
                    bc.MaxHeight = _maxBlobHeight;
                }
            }

            // Scans the image for blobs, prepping the BlobCounter for future operations
            bc.ProcessImage(image);

            return bc.GetObjects(image, true);
        }

        /// <summary>
        /// Merges overlapping blobs in a list of blobs.
        /// </summary>
        /// <param name="blobs">A list of blobs</param>
        /// <returns>The list of blobs with overlapping blobs merged into single blobs.</returns>
        protected virtual IList<IBlob> MergeOverlappingBlobs(IEnumerable<IBlob> blobs)
        {
            List<IBlob> mergedBlobs = new List<IBlob>();
            Queue<IBlob> blobQueue = new Queue<IBlob>();
            foreach (var blob in blobs)
            {
                blobQueue.Enqueue(blob);
            }

            while(blobQueue.Count > 0)
            {
                IBlob currBlob = blobQueue.Dequeue();

                bool mergedBlob = false;
                foreach (var blob in mergedBlobs)
                {
                    Rectangle currRect = new Rectangle(currBlob.Position, currBlob.Dimension);
                    Rectangle blobRect = new Rectangle(blob.Position, blob.Dimension);

                    if (!currRect.IntersectsWith(blobRect))
                    {
                        continue;
                    }

                    MergedBlob mBlob = new MergedBlob(currBlob);
                    mBlob.AddBlob(blob);
                    mergedBlobs.Remove(blob);
                    blobQueue.Enqueue(mBlob);
                    mergedBlob = true;
                    break;
                }

                if (!mergedBlob)
                {
                    mergedBlobs.Add(currBlob);
                }
            }

            return mergedBlobs;
        }
    }
}