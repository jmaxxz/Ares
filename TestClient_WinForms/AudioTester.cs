/*
 *  Ares, a multi-player augmented reality first person shooter
 *  Copyright (C) 2009  Jmaxxz, Mike McBride, and Kevin Curtis
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
 * 0.95     mcbridem Initial development                Fully defined every method (1/14/10)
 * 0.95     mcbridem Code review                        Added default locations to the sound files, allowed for
 *                                                      manual editing of file path text boxes.
 */

using System.Windows.Forms;

namespace Ares.Client.Test.Audio
{
    using Client.Audio;
    public partial class AudioTester : Form
    {
        private ISoundMapping _soundMapping;
        private IAudioEngine _audioEngine;

        public AudioTester()
        {
            InitializeComponent();
        }

        // NOTE - C# only supports PCM wav files, so make sure your wav files are PCM through Sound Recorder or otherwise. - MGM
        private static void chooseFile(Control textbox)
        {
            var fd = new OpenFileDialog
                         {
                             InitialDirectory = textbox.Text == "" ? "..\\..\\..\\..\\sounds\\" : textbox.Text
                         };
            fd.ShowDialog();
            textbox.Text = fd.FileName;
        }

        private void btnShootingFile_Click(object sender, System.EventArgs e)
        {
            chooseFile(txtShooting);
        }

        private void btnKillingFile_Click(object sender, System.EventArgs e)
        {
            chooseFile(txtKilling);
        }

        private void btnDyingFile_Click(object sender, System.EventArgs e)
        {
            chooseFile(txtDying);
        }

        private void btnDoingDamageFile_Click(object sender, System.EventArgs e)
        {
            chooseFile(txtDoingDamage);
        }

        private void btnTakingDamageFile_Click(object sender, System.EventArgs e)
        {
            chooseFile(txtTakingDamage);
        }

        private void btnInitializeMapping_Click(object sender, System.EventArgs e)
        {
            _soundMapping = new SoundMapping(txtShooting.Text != "" ? txtShooting.Text : null,
                                             txtKilling.Text != "" ? txtKilling.Text : null,
                                             txtDying.Text != "" ? txtDying.Text : null,
                                             txtDoingDamage.Text != "" ? txtDoingDamage.Text : null,
                                             txtTakingDamage.Text != "" ? txtTakingDamage.Text : null);


            btnPlayShooting.Enabled = false;
            btnPlayKilling.Enabled = false;
            btnPlayDying.Enabled = false;
            btnPlayDoingDamage.Enabled = false;
            btnPlayTakingDamage.Enabled = false;

            btnInitializeAudioEngine.Enabled = true;
        }

        private void btnInitializeAudioEngine_Click(object sender, System.EventArgs e)
        {
            _audioEngine = new AudioEngine(_soundMapping);

            btnPlayShooting.Enabled = true;
            btnPlayKilling.Enabled = true;
            btnPlayDying.Enabled = true;
            btnPlayDoingDamage.Enabled = true;
            btnPlayTakingDamage.Enabled = true;
        }

        private void btnPlayShooting_Click(object sender, System.EventArgs e)
        {
            _audioEngine.PlayShooting(0);
        }

        private void btnPlayKilling_Click(object sender, System.EventArgs e)
        {
            _audioEngine.PlayKilling();
        }

        private void btnPlayDying_Click(object sender, System.EventArgs e)
        {
            _audioEngine.PlayDying();
        }

        private void btnPlayDoingDamage_Click(object sender, System.EventArgs e)
        {
            _audioEngine.PlayDoingDamage();
        }

        private void btnPlayTakingDamage_Click(object sender, System.EventArgs e)
        {
            _audioEngine.PlayTakingDamage();
        }
    }
}


