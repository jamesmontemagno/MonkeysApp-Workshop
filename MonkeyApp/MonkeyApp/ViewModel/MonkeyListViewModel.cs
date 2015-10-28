using MonkeyApp.Model;
using MonkeyApp.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MonkeyApp.ViewModel
{
    public class MonkeyListViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Monkey> Monkeys { get; set; }

        INavigation navigation;
        public MonkeyListViewModel(INavigation navigation)
        {
            this.navigation = navigation;
            Monkeys = new ObservableCollection<Monkey>();
        }

        Monkey selectedMonkey;
        public Monkey SelectedMonkey
        {
            get { return selectedMonkey; }
            set
            {
                selectedMonkey = value;
                OnPropertyChanged("SelectedMonkey");
                if (selectedMonkey == null)
                    return;

                var page = new MonkeyPage(selectedMonkey);

                SelectedMonkey = null;
                navigation.PushAsync(page);
            }
        }


        bool busy;

        public bool IsBusy
        {
            get { return busy; }
            set
            {
                if (busy == value)
                    return;

                busy = value;
                OnPropertyChanged("IsBusy");
                GetMonkeysCommand.ChangeCanExecute();
            }
        }

        Command getMonkeysCommand;
        public Command GetMonkeysCommand
        {
            get
            {
                return getMonkeysCommand ??
                 (getMonkeysCommand =
                 new Command(async () => await GetMonkeysAsync(),
                 () => !IsBusy));
            }
        }

        public async Task GetMonkeysAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                Monkeys.Clear();
                var client = new HttpClient();
                var json = await client.GetStringAsync("http://montemagno.com/monkeys.json");

                var list = JsonConvert.DeserializeObject<List<Monkey>>(json);
                foreach (var item in list)
                {
                    Monkeys.Add(item);
                }

            }
            catch(Exception ex)
            {
                MessagingCenter.Send(ex, "error");
            }
            finally
            {
                IsBusy = false;
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed(this, new PropertyChangedEventArgs(name));
        }


    }
}
