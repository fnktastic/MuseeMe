using MuseeMe.Model;
using MuseeMe.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MuseeMe
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<MenuItemTypeEnum, NavigationPage> MenuPages = new Dictionary<MenuItemTypeEnum, NavigationPage>();

        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add(MenuItemTypeEnum.Home, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(MenuItemTypeEnum id)
        {
            if(MenuPages.ContainsKey(id) == false)
            {
                switch (id)
                {
                    case MenuItemTypeEnum.Home:
                        MenuPages.Add(id, new NavigationPage(new HomePage()));
                        break;
                    case MenuItemTypeEnum.Audios:
                        MenuPages.Add(id, new NavigationPage(new AudiosPage()));
                        break;
                    case MenuItemTypeEnum.About:
                        MenuPages.Add(id, new NavigationPage(new AboutPage()));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if(newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}
