using System;
using System.Windows.Forms;
using System.Speech;
using System.Speech.Synthesis;

namespace TextToSpeechConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //SpeechSynthesizer Class Provides access to the functionality of an installed a speech synthesis engine.    
        SpeechSynthesizer speechSynthesizerObj;
        private void Form1_Load(object sender, EventArgs e)
        {
            speechSynthesizerObj = new SpeechSynthesizer();
            BtnResume.Enabled = false;
            BtnPause.Enabled = false;
            BtnStop.Enabled = false;
        }


        private void BtnSpeak_Click(object sender, EventArgs e)
        {
            //Disposes the SpeechSynthesizer object    
            speechSynthesizerObj.Dispose();
            if (richTextBox1.Text != "")
            {
                speechSynthesizerObj = new SpeechSynthesizer();
                //Asynchronously speaks the contents present in RichTextBox1    
                speechSynthesizerObj.SpeakAsync(richTextBox1.Text);
                BtnPause.Enabled = true;
                BtnStop.Enabled = true;
            }
            }

        private void BtnPause_Click(object sender, EventArgs e)
        {
            if (speechSynthesizerObj != null)
            {
                //Gets the current speaking state of the SpeechSynthesizer object.    
                if (speechSynthesizerObj.State == SynthesizerState.Speaking)
                {
                    //Pauses the SpeechSynthesizer object.    
                    speechSynthesizerObj.Pause();
                    BtnResume.Enabled = true;
                    BtnSpeak.Enabled = false;
                }
            }
        }

        private void BtnResume_Click(object sender, EventArgs e)
        {
            if (speechSynthesizerObj != null)
            {
                if (speechSynthesizerObj.State == SynthesizerState.Paused)
                {
                    //Resumes the SpeechSynthesizer object after it has been paused.    
                    speechSynthesizerObj.Resume();
                    BtnResume.Enabled = false;
                    BtnSpeak.Enabled = true;
                }
            }
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            if (speechSynthesizerObj != null)
            {
                //Disposes the SpeechSynthesizer object    
                speechSynthesizerObj.Dispose();
                BtnSpeak.Enabled = true;
                BtnResume.Enabled = false;
                BtnPause.Enabled = false;
                BtnStop.Enabled = false;
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}