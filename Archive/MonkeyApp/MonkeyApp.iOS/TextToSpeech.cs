using AVFoundation;
using MonkeyApp.Interfaces;
using MonkeyApp.iOS;
using Xamarin.Forms;

[assembly:Dependency(typeof(TextToSpeech))]
namespace MonkeyApp.iOS
{
    public class TextToSpeech : ITextToSpeech
    {
        public TextToSpeech() { }

        public void Speak(string text)
        {
            var speechSynthesizer = new AVSpeechSynthesizer();

            var speechUtterance = new AVSpeechUtterance(text)
            {
                Rate = AVSpeechUtterance.MaximumSpeechRate / 4,
                Voice = AVSpeechSynthesisVoice.FromLanguage("en-US"),
                Volume = 0.5f,
                PitchMultiplier = 1.0f
            };

            speechSynthesizer.SpeakUtterance(speechUtterance);
        }
    }
}
