using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;

using System.Linq;
using MonkeyFinder.Model;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace MonkeyFinder.ViewModel
{
    public class MonkeysViewModel : BaseViewModel
    {
        public ObservableCollection<Monkey> Monkeys { get; }
        public ICommand GetMonkeysCommand { get; }
        public ICommand GetClosestCommand { get; }
        public MonkeysViewModel()
        {
            Monkeys = new ObservableCollection<Monkey>();
            GetMonkeysCommand = new Command(async () => await GetMonkeysAsync());
            GetClosestCommand = new Command(async () => await GetClosestAsync());
        }

        async Task GetClosestAsync()
        {
            if (Monkeys.Count == 0)
                return;

            if (IsBusy)
                return;
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();
                if (location == null)
                {
                    location = await Geolocation.GetLocationAsync(new GeolocationRequest
                    {
                        DesiredAccuracy = GeolocationAccuracy.Medium,
                        Timeout = TimeSpan.FromSeconds(30)
                    });
                }

                var first = Monkeys.OrderBy(m => location.CalculateDistance(
                    new Location(m.Latitude, m.Longitude), DistanceUnits.Miles))
                    .FirstOrDefault();

                await Application.Current.MainPage.DisplayAlert("", first.Name + " " +
                    first.Location, "OK");

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to query location: {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("Something is wrong",
                       "Unable to get location! :(", "OK");
            }
        }

        async Task GetMonkeysAsync()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            try
            {
                Monkeys.Clear();
                var monkeys = await DataService.GetMonkeysAsync();
                foreach (var monkey in monkeys)
                    Monkeys.Add(monkey);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to query location: {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("Something is wrong",
                    "OH MY GOODNESS! :(", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }


    }
}
