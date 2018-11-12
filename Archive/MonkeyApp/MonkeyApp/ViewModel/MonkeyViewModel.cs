using MonkeyApp.Model;
using Refractored.Xam.TTS;
using Xamarin.Forms;

namespace MonkeyApp.ViewModel
{
    public class MonkeyViewModel
    {
        public Monkey Monkey { get; set; }
        public MonkeyViewModel(Monkey monkey)
        {
            Monkey = monkey;
        }

        Command<string> speakCommand;
        public Command SpeakCommand
        {
            get
            {
                return speakCommand ??
                 (speakCommand = new Command<string>(
                     text =>
                     {
                         CrossTextToSpeech.Current.Speak(text);
                     } ));
            }
        }
    }
}
