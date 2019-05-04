using System.Collections.ObjectModel;
using CoffeeShopXamarinApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoffeeShopXamarinApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SubMenuPage : ContentPage
    {

        public ObservableCollection<SubMenu> SubMenus;

		public SubMenuPage (Models.Menu menu)
		{
			InitializeComponent ();

            SubMenus = new ObservableCollection<SubMenu>();

            foreach (var subMenu in menu.SubMenus)
            {
                subMenu.Price += " USD";
                SubMenus.Add(subMenu);
            }

            LvSubMenu.ItemsSource = SubMenus;
        }
	}
}