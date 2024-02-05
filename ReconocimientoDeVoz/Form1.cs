using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;

namespace ReconocimientoDeVoz
{
    public partial class Form1 : Form
    {
        SpeechRecognitionEngine oEscucha = new SpeechRecognitionEngine();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            oEscucha.SetInputToDefaultAudioDevice();
            oEscucha.LoadGrammar(new DictationGrammar());
            oEscucha.SpeechRecognized += Detection;
            oEscucha.RecognizeAsync(RecognizeMode.Multiple);

        }

        private void Detection(object sender, SpeechRecognizedEventArgs e)
        {
            textBox1.Text = e.Result.Text;
        }

        private void btnDetener_Click(object sender, EventArgs e)
        {
            oEscucha.RecognizeAsyncStop();
        }
    }
}
