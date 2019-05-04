using System.Collections.Generic;

namespace CoffeeShopXamarinApp.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public IList<SubMenu> SubMenus { get; set; }
    }
}