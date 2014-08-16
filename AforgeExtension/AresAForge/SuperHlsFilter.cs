
// Copyright © Andrew Kirillov, 2005-2009
// Copyright (C) 2010  Jmaxxz, Mike McBride, and Kevin Curtis
// This Library is under the LGPL version 3 License


//


using System.Collections.Generic;
using System.Drawing.Imaging;
using AForge;
using AForge.Imaging;
using AForge.Imaging.Filters;

namespace Ares.Client.Analysis.AresAForge
{
    /// <summary>
    /// Color filtering in HSL color space.
    /// </summary>
    /// 
    /// <remarks><para>The filter operates in <b>HSL</b> color space and filters
    /// pixels, which color is inside/outside of the specified HSL range -
    /// it keeps pixels with colors inside/outside of the specified range and fills the
    /// rest with <see cref="FillColor">specified color</see>.</para>
    /// 
    /// <para>The filter accepts 24 and 32 bpp color images for processing.</para>
    /// 
    /// <para>Sample usage:</para>
    /// <code>
    /// // create filter
    /// HSLFiltering filter = new HSLFiltering( );
    /// // set color ranges to keep
    /// filter.Hue = new IntRange( 335, 0 );
    /// filter.Saturation = new DoubleRange( 0.6, 1 );
    /// filter.Luminance = new DoubleRange( 0.1, 1 );
    /// // apply the filter
    /// filter.ApplyInPlace( image );
    /// </code>
    /// 
    /// <para><b>Initial image:</b></para>
    /// <img src="img/imaging/sample1.jpg" width="480" height="361" />
    /// <para><b>Result image:</b></para>
    /// <img src="img/imaging/hsl_filtering.jpg" width="480" height="361" />
    /// 
    /// <para>Sample usage with saturation update only:</para>
    /// <code>
    /// // create filter
    /// HSLFiltering filter = new HSLFiltering( );
    /// // configure the filter
    /// filter.Hue = new IntRange( 340, 20 );
    /// filter.UpdateLuminance = false;
    /// filter.UpdateHue = false;
    /// // apply the filter
    /// filter.ApplyInPlace( image );
    /// </code>
    /// 
    /// <para><b>Result image:</b></para>
    /// <img src="img/imaging/hsl_filtering2.jpg" width="480" height="361" />
    /// </remarks>
    /// 
    /// <seealso cref="ColorFiltering"/>
    /// <seealso cref="YCbCrFiltering"/>
    /// 
    public class SuperHlsFilter : BaseFilter
    {
        private IntRange hue = new IntRange(0, 359);
        private DoubleRange saturation = new DoubleRange(0.0, 1.0);
        private DoubleRange luminance = new DoubleRange(0.0, 1.0);


        // private format translation dictionary
        private Dictionary<PixelFormat, PixelFormat> formatTransalations = new Dictionary<PixelFormat, PixelFormat>();

        /// <summary>
        /// Format translations dictionary.
        /// </summary>
        public override Dictionary<PixelFormat, PixelFormat> FormatTransalations
        {
            get { return formatTransalations; }
        }

        #region Public properties

        /// <summary>
        /// Range of hue component, [0, 359].
        /// </summary>
        /// 
        /// <remarks><note>Because of hue values are cycled, the minimum value of the hue
        /// range may have bigger integer value than the maximum value, for example [330, 30].</note></remarks>
        /// 
        public IntRange Hue
        {
            get { return hue; }
            set { hue = value; }
        }

        /// <summary>
        /// Range of saturation component, [0, 1].
        /// </summary>
        public DoubleRange Saturation
        {
            get { return saturation; }
            set { saturation = value; }
        }

        /// <summary>
        /// Range of luminance component, [0, 1].
        /// </summary>
        public DoubleRange Luminance
        {
            get { return luminance; }
            set { luminance = value; }
        }


        #endregion


        /// <summary>
        /// Initializes a new instance of the <see cref="HSLFiltering"/> class.
        /// </summary>
        public SuperHlsFilter()
        {
            formatTransalations[PixelFormat.Format24bppRgb] = PixelFormat.Format8bppIndexed;
            formatTransalations[PixelFormat.Format32bppRgb] = PixelFormat.Format8bppIndexed;
            formatTransalations[PixelFormat.Format32bppArgb] = PixelFormat.Format8bppIndexed;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HSLFiltering"/> class.
        /// </summary>
        /// 
        /// <param name="hue">Range of hue component.</param>
        /// <param name="saturation">Range of saturation component.</param>
        /// <param name="luminance">Range of luminance component.</param>
        /// 
        public SuperHlsFilter(IntRange hue, DoubleRange saturation, DoubleRange luminance) :
            this()
        {
            this.hue = hue;
            this.saturation = saturation;
            this.luminance = luminance;
        }

        /// <summary>
        /// Process the filter on the specified image.
        /// </summary>
        /// 
        /// <param name="image">Source image data.</param>
        /// <param name="rect">Image rectangle for processing by the filter.</param>
        ///
        protected override unsafe void ProcessFilter(UnmanagedImage sourceData, UnmanagedImage destinationData)
        {

            // get width and height
            int width = sourceData.Width;
            int height = sourceData.Height;
            PixelFormat srcPixelFormat = sourceData.PixelFormat;
            
            // get pixel size
            int pixelSize = (srcPixelFormat == PixelFormat.Format24bppRgb) ? 3 : 4;
            int srcOffset = sourceData.Stride - width * pixelSize;
            int dstOffset = destinationData.Stride - width;

            // do the job
            byte* ptr = (byte*)sourceData.ImageData.ToPointer();
            byte* dst = (byte*)destinationData.ImageData.ToPointer();

            if (MultiThreaded)
            {
                // for each row
                Concurrent.For(0, height, y => AnalyzeRow(width, dst, y, dstOffset, ptr, pixelSize, srcOffset));
                
            }
            else
            {
                for (int y = 0; y < height; y++)
                {
                    // for each pixel
                    AnalyzeRow(width, dst, y, dstOffset, ptr, pixelSize, srcOffset);
                }
            }
            Dialate(destinationData);
        }

        public bool MultiThreaded { get; set; }

        private unsafe void Dialate(UnmanagedImage destination)
        {
            using (UnmanagedImage source = destination.Clone())
            {

                // get width and height
                int width = source.Width;
                int height = source.Height;

                // get extra buffersize
                int srcOffset = source.Stride - width;
                int dstOffset = destination.Stride - width;

                // do the job
                byte* src = (byte*) source.ImageData.ToPointer();
                byte* dst = (byte*) destination.ImageData.ToPointer();

                DialateTop(width, dst, 0, dstOffset, src, srcOffset, source.Stride);

                if (MultiThreaded)
                {
                    Concurrent.For(1, height - 1, y => Dialate(width, dst, y, dstOffset, src, srcOffset, source.Stride));
                }
                else
                {
                    for (int y = 1; y < height - 1; y++)
                    {
                        Dialate(width, dst, y, dstOffset, src, srcOffset, source.Stride);
                    }
                }


                DialateBottom(width, dst, height - 1, dstOffset, src, srcOffset, source.Stride);
            }

        }
        private unsafe void DialateTop(int width, byte* dst, int y, int dstOffset, byte* src, int srcOffset, int srcStride)
        {
            byte* tmpDst = dst + y * dstOffset + y * width;
            byte* tmpSrc = src + y * srcOffset + y * width;

            byte max;


            //Handle first pixel in row
            max = *tmpSrc;

            if (tmpSrc[1] > max)
                max = tmpSrc[1];
            if (tmpSrc[srcStride] > max)
                max = tmpSrc[srcStride];
            if (tmpSrc[srcStride + 1] > max)
                max = tmpSrc[srcStride + 1];


            *tmpDst = max;
            tmpDst++;
            tmpSrc++;

            // for each pixel
            for (int x = 1; x < width - 1; x++, tmpSrc++, tmpDst++)
            {
                max = *tmpSrc;

                if (tmpSrc[-1] > max)
                    max = tmpSrc[-1];
                if (tmpSrc[1] > max)
                    max = tmpSrc[1];
                if (tmpSrc[srcStride - 1] > max)
                    max = tmpSrc[srcStride - 1];
                if (tmpSrc[srcStride] > max)
                    max = tmpSrc[srcStride];
                if (tmpSrc[srcStride + 1] > max)
                    max = tmpSrc[srcStride + 1];
                *tmpDst = max;
            }

            //handle last pixel in row
            max = *tmpSrc;

            if (tmpSrc[-1] > max)
                max = tmpSrc[-1];
            if (tmpSrc[srcStride - 1] > max)
                max = tmpSrc[srcStride - 1];
            if (tmpSrc[srcStride] > max)
                max = tmpSrc[srcStride];


            *tmpDst = max;
        }



        private unsafe void DialateBottom(int width, byte* dst, int y, int dstOffset, byte* src, int srcOffset, int srcStride)
        {
            byte* tmpDst = dst + y * dstOffset + y * width;
            byte* tmpSrc = src + y * srcOffset + y * width;

            byte max;


            //Handle first pixel in row
            max = *tmpSrc;

            if (tmpSrc[1] > max)
                max = tmpSrc[1];
            if (tmpSrc[-srcStride] > max)
                max = tmpSrc[-srcStride];
            if (tmpSrc[-srcStride + 1] > max)
                max = tmpSrc[-srcStride + 1];


            *tmpDst = max;
            tmpDst++;
            tmpSrc++;

            // for each pixel
            for (int x = 1; x < width - 1; x++, tmpSrc++, tmpDst++)
            {
                max = *tmpSrc;

                if (tmpSrc[-1] > max)
                    max = tmpSrc[-1];
                if (tmpSrc[1] > max)
                    max = tmpSrc[1];
                if (tmpSrc[-srcStride - 1] > max)
                    max = tmpSrc[-srcStride - 1];
                if (tmpSrc[-srcStride] > max)
                    max = tmpSrc[-srcStride];
                if (tmpSrc[-srcStride + 1] > max)
                    max = tmpSrc[-srcStride + 1];
                *tmpDst = max;
            }

            //handle last pixel in row
            max = *tmpSrc;

            if (tmpSrc[-1] > max)
                max = tmpSrc[-1];
            if (tmpSrc[-srcStride - 1] > max)
                max = tmpSrc[-srcStride - 1];
            if (tmpSrc[-srcStride] > max)
                max = tmpSrc[-srcStride];

            *tmpDst = max;
        }


        private unsafe void Dialate(int width, byte* dst, int y, int dstOffset, byte* src, int srcOffset, int srcStride)
        {
            byte* tmpDst = dst + y * dstOffset + y * width;
            byte* tmpSrc = src + y * srcOffset + y * width;

            byte max;


            //Handle first pixel in row
            max = *tmpSrc;

            if (tmpSrc[1] > max)
                max = tmpSrc[1];
            if (tmpSrc[-srcStride] > max)
                max = tmpSrc[-srcStride];
            if (tmpSrc[-srcStride + 1] > max)
                max = tmpSrc[-srcStride + 1];
            if (tmpSrc[srcStride] > max)
                max = tmpSrc[srcStride];
            if (tmpSrc[srcStride + 1] > max)
                max = tmpSrc[srcStride + 1];

            *tmpDst = max;
            tmpDst++;
            tmpSrc++;

                // for each pixel
            for (int x = 1; x < width-1; x++, tmpSrc++, tmpDst++)
            {
                    max = *tmpSrc;

                    if (tmpSrc[-1] > max)
                        max = tmpSrc[-1];
                    if (tmpSrc[1] > max)
                        max = tmpSrc[1];
                    if (tmpSrc[-srcStride - 1] > max)
                        max = tmpSrc[-srcStride - 1];
                    if (tmpSrc[-srcStride] > max)
                        max = tmpSrc[-srcStride];
                    if (tmpSrc[-srcStride + 1] > max)
                        max = tmpSrc[-srcStride + 1];
                    if (tmpSrc[srcStride - 1] > max)
                        max = tmpSrc[srcStride - 1];
                    if (tmpSrc[srcStride] > max)
                        max = tmpSrc[srcStride];
                    if (tmpSrc[srcStride + 1] > max)
                        max = tmpSrc[srcStride + 1];

                    *tmpDst = max;
            }

            //handle last pixel in row
            max = *tmpSrc;

            if (tmpSrc[-1] > max)
                max = tmpSrc[-1];
            if (tmpSrc[-srcStride - 1] > max)
                max = tmpSrc[-srcStride - 1];
            if (tmpSrc[-srcStride] > max)
                max = tmpSrc[-srcStride];
            if (tmpSrc[srcStride - 1] > max)
                max = src[srcStride - 1];
            if (tmpSrc[srcStride] > max)
                max = tmpSrc[srcStride];

            *tmpDst = max;

        }

        private unsafe void AnalyzeRow(int width, byte* dst, int y, int dstOffset, byte* ptr, int pixelSize, int srcOffset)
        {

            HSL hsl = new HSL();
            RGB rgb = new RGB();
            byte* tmpDst = dst + y * dstOffset + y * width;
            byte* tmpSrc = ptr + y * srcOffset + y * width * pixelSize;
            

            for (int x = 0; x < width; x++, tmpSrc += pixelSize, tmpDst++)
            {
                rgb.Red = tmpSrc[RGB.R];
                rgb.Green = tmpSrc[RGB.G];
                rgb.Blue = tmpSrc[RGB.B];
                

                // convert to HSL
                HSL.FromRGB(rgb, hsl);

                // check HSL values
                if (
                        (hsl.Saturation >= saturation.Min) &&
                        (hsl.Saturation <= saturation.Max) &&
                        (hsl.Luminance >= luminance.Min) &&
                        (hsl.Luminance <= luminance.Max) &&
                        (
                            ((hue.Min < hue.Max) && (hsl.Hue >= hue.Min) && (hsl.Hue <= hue.Max)) ||
                            ((hue.Min > hue.Max) && ((hsl.Hue >= hue.Min) || (hsl.Hue <= hue.Max)))
                        )
                    )
                {
                    *tmpDst = (byte) (0.2125*rgb.Red + 0.7154*rgb.Green + 0.0721*rgb.Blue);
                }
                else
                {
                    *tmpDst = 0;
                }
            }
        }
    }
}


