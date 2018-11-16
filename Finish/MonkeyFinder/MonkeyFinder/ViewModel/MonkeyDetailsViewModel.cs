using MonkeyFinder.Model;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MonkeyFinder.ViewModel
{
    public class MonkeyDetailsViewModel : BaseViewModel
    {
        public Command OpenMapCommand { get; }

        public Command SaveDetailsCommand { get; }

        public MonkeyDetailsViewModel()
        {

            OpenMapCommand = new Command(async () => await OpenMapAsync());
            SaveDetailsCommand = new Command(async () => await SaveMonkey());
        }

        public MonkeyDetailsViewModel(Monkey monkey)
            : this()
        {
            Monkey = monkey;
            Title = $"{Monkey.Name} Details";
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

        async Task OpenMapAsync()
        {
            try
            {
                await Maps.OpenAsync(Monkey.Latitude, Monkey.Longitude);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to launch maps: {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("Error, no Maps app!", ex.Message, "OK");
            }
        }

        async Task SaveMonkey()
        {
            try
            {
                await DataService.UpdateDetails(monkey.Details, monkey.Id);
                await Application.Current.MainPage.DisplayAlert("Saved!", "Saved!", "OK");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to save monkey details: {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("Error, no saving!", ex.Message, "OK");
            }
        }
    }
}
