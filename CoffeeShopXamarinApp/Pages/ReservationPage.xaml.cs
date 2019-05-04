using System;
using System.Globalization;
using CoffeeShopXamarinApp.Models;
using CoffeeShopXamarinApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoffeeShopXamarinApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReservationPage : ContentPage
    {
        public ReservationPage()
        {
            InitializeComponent();
        }

        private async void BtnBookTable_OnClicked(object sender, EventArgs e)
        {
            try
            {
                var reservation = new Reservation
                {
                    Name = EntName.Text,
                    Email = EntEmail.Text,
                    Phone = EntPhone.Text,
                    TotalPeople = short.Parse(EntPeople.Text),
                    Date = DpBookingDate.Date.ToString(CultureInfo.InvariantCulture),
                    Time = TpBookingTime.Time.ToString()
                };

                var apiServices = new ApiServices();
                var response = await apiServices.ReserveTable(reservation);
                if (!response)
                {
                    await DisplayAlert("Ooops", "Something went wrong, please try again", "Ok");
                }
                else
                {
                    await DisplayAlert("Thanks", "Your table was reserved successfully", "Ok");
                }
            }
            catch (Exception)
            {
                await DisplayAlert("Ooops", "Please add number of people in your reservation", "Ok");
            }
        }
    }
}