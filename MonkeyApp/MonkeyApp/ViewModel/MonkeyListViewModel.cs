using MonkeyApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyApp.ViewModel
{
    public class MonkeyListViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Monkey> Monkeys { get; set; }

        public MonkeyListViewModel()
        {
            Monkeys = new ObservableCollection<Monkey>();
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
            }
        }

        public async Task GetMonkeysAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                var client = new HttpClient();
                var json = await client.GetStringAsync("http://montemagno.com/monkeys.json");

                var list = JsonConvert.DeserializeObject<List<Monkey>>(json);
                foreach (var item in list)
                {
                    Monkeys.Add(item);
                }

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
