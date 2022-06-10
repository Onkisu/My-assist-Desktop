using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Speech.Recognition;

namespace MyAssistant
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_listen_Click(object sender, EventArgs e)
        {
            if (txtSTT.Text!="")
            {
                
                SpeechSynthesizer ss = new SpeechSynthesizer();
              
                ss.SelectVoiceByHints((VoiceGender)VoiceAge.Child);
                ss.Volume = trackBar1.Value;
                ss.Speak(txtSTT.Text);
            }
            else
            {
                MessageBox.Show("Please Write Something first!");
            }
        }

        private void btn_read_Click(object sender, EventArgs e)
        {
            SpeechRecognitionEngine sr = new SpeechRecognitionEngine();
            Grammar words = new DictationGrammar();
            sr.LoadGrammar(words);
            try
            {
                txtTTS.Text = "Listening Now...";
                sr.SetInputToDefaultAudioDevice();
                RecognitionResult result = sr.Recognize();
                txtTTS.Clear();
                txtTTS.Text = result.Text;
            }
            catch(Exception ex)
            {
                txtTTS.Text = "";
                MessageBox.Show("Mic Not Found!");
            }
        }
    }
}
