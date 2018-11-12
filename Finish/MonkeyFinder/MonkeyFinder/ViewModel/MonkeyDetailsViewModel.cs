using MonkeyFinder.Model;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MonkeyFinder.ViewModel
{
    public class MonkeyDetailsViewModel : BaseViewModel
    {
        public ICommand OpenMapCommand { get; }

        public MonkeyDetailsViewModel()
        {
            OpenMapCommand = new Command(async () => await ExecuteOpenMapCommand()); 
        }

        public MonkeyDetailsViewModel(Monkey monkey) 
            : this()
        {
            Monkey = monkey;
        }

        Task ExecuteOpenMapCommand()
        {
           return Maps.OpenAsync(Monkey.Latitude, Monkey.Longitude);
        }

        Monkey monkey;
        public Monkey Monkey
        {
            get => monkey;
            set
            {
                if (monkey == value)
                    return;

                monkey = value;
                OnPropertyChanged();
            }
        }
    }
}
