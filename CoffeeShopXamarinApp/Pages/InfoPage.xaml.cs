using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoffeeShopXamarinApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfoPage : ContentPage
    {
        public InfoPage()
        {
            InitializeComponent();
        }

        private void TapFacebook_OnTapped(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://www.luisinacio.co.uk"));
        }

        private void TapCall_OnTapped(object sender, EventArgs e)
        {
            PhoneDialer.Open("9644866331");
        }
    }
}