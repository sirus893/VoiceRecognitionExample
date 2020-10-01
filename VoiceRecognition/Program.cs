using System;
using System.Speech.Recognition;

namespace VoiceRecognition
{
    class Program
    {
        static void Main(string[] args)
        {
            GrammarBuilder gb = new GrammarBuilder("hello computer");
            

            Choices choices = new Choices();
            choices.Add("hello computer");
            choices.Add("hello");

            Grammar gr = new Grammar(new GrammarBuilder(choices));
            SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine(SpeechRecognitionEngine.InstalledRecognizers()[0]);

            recognizer.LoadGrammar(gr);
            recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sr_SpeechRecognized);
            recognizer.SetInputToDefaultAudioDevice();
            recognizer.RecognizeAsync(RecognizeMode.Multiple);

        }

        static void sr_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Text == "hello computer")
            {
                Console.WriteLine("hello user");
            }
        }
    }
}
