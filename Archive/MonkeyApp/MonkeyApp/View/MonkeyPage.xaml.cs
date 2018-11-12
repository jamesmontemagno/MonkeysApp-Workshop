using MonkeyApp.Interfaces;
using MonkeyApp.Model;
using MonkeyApp.ViewModel;
using Refractored.Xam.TTS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MonkeyApp.View
{
    public partial class MonkeyPage : ContentPage
    {
        public MonkeyPage(Monkey monkey)
        {
            InitializeComponent();
            BindingContext = new MonkeyViewModel(monkey);

            ButtonDismiss.Clicked += (sender, args) =>
            {
                Navigation.PopAsync(true);
            };
        }
    }
}
