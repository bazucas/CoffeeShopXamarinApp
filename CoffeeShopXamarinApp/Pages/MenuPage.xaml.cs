using System.Collections.ObjectModel;
using CoffeeShopXamarinApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Menu = CoffeeShopXamarinApp.Models.Menu;

namespace CoffeeShopXamarinApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        public ObservableCollection<Models.Menu> Menus;
        public static bool First = true;

        public MenuPage()
        {
            InitializeComponent();

            Menus = new ObservableCollection<Models.Menu>();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (First)
            {
                var apiService = new ApiServices();
                var menus = await apiService.GetMenu();
                foreach (var menu in menus)
                {
                    Menus.Add(menu);
                }

                LvMenu.ItemsSource = Menus;
                BusyIndicator.IsRunning = false;
            }

            First = false;
        }

        private void LvMenu_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is Menu selectedMenu)
            {
                Navigation.PushAsync(new SubMenuPage(selectedMenu));
            }

            ((ListView) sender).SelectedItem = null;
        }
    }
}