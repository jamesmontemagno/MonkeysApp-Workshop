using MonkeyApp.Interfaces;
using System;
using Windows.Phone.Speech.Synthesis;

namespace MonkeyApp.WinPhone
{
    public class TextToSpeech_WinPhone : ITextToSpeech
    {
        public TextToSpeech_WinPhone() { }

        public async void Speak(string text)
        {
            var synth = new SpeechSynthesizer();
            await synth.SpeakTextAsync(text);
        }
    }
}
