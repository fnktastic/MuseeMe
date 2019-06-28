using MuseeMe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MuseeMe.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuPage : ContentPage
	{
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }

        List<MainMenuItem> menuItems;

		public MenuPage ()
		{
			InitializeComponent ();

            menuItems = new List<MainMenuItem>
            {
                new MainMenuItem { MenuItem = MenuItemTypeEnum.Home, Title = "Home" },
                new MainMenuItem { MenuItem = MenuItemTypeEnum.Audios, Title = "Library" },
                new MainMenuItem { MenuItem = MenuItemTypeEnum.About, Title = "About"}
            };

            ListViewMainMenu.ItemsSource = menuItems;

            ListViewMainMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = ((MainMenuItem)e.SelectedItem).MenuItem;

                await RootPage.NavigateFromMenu(id);
            };
		}
	}
}