using MonkeyApp.Model;
using MonkeyApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MonkeyApp.View
{
    public partial class MonkeyListPage : ContentPage
    {
        MonkeyListViewModel vm;
        public MonkeyListPage()
        {
            InitializeComponent();
            vm = new MonkeyListViewModel(Navigation);
            BindingContext = vm;
         
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (vm.Monkeys.Count == 0)
                vm.GetMonkeysCommand.Execute(null);

            MessagingCenter.Subscribe<Exception>(this, "error", async (ex) =>
            {
                await DisplayAlert("Error", "Unable to get monkeys: " + ex.Message, "OK");
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Exception>(this, "error");
        }
    }
}
