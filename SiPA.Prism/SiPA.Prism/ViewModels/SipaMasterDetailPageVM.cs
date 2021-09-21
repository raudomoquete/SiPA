using Prism.Navigation;
using SiPA.Common.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SiPA.Prism.ViewModels
{
    public class SipaMasterDetailPageVM : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public SipaMasterDetailPageVM(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
            LoadMenus();
        }

        public ObservableCollection<MenuItemViewModel> Menus { get; set; }

        private void LoadMenus()
        {
            var menus = new List<Menu>
            {
                new Menu
                {
                    Icon = "ic_sacraments_menu",
                    PageName = "SacramentsPage",
                    Title = "My Sacraments"
                },

                new Menu
                {
                    Icon = "ic_list_alt",
                    PageName = "RequestPage",
                    Title = "My Requests"
                },

                new Menu
                {
                    Icon = "ic_map",
                    PageName = "MapPage",
                    Title = "Map"
                },

                new Menu
                {
                    Icon = "ic_person",
                    PageName = "ProfilePage",
                    Title = "Modify Profile"
                },

                new Menu
                {
                    Icon = "ic_exit_to_app",
                    PageName = "LoginPage",
                    Title = "Logout"
                }
            };

            Menus = new ObservableCollection<MenuItemViewModel>(
                menus.Select(m => new MenuItemViewModel(_navigationService)
                {
                    Icon = m.Icon,
                    PageName = m.PageName,
                    Title = m.Title
                }).ToList());
        }
    
    }
}
