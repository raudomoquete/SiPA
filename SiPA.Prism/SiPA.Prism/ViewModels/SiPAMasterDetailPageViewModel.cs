using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SiPA.Prism.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SiPA.Prism.ViewModels
{
    public class SiPAMasterDetailPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        public SiPAMasterDetailPageViewModel(INavigationService navigationService) : base(navigationService)
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
                    Icon = "ic_list_alt",
                    PageName = "Requests",
                    Title = "Mis Solicitudes"
                },
                new Menu
                {
                    Icon ="ic_person",
                    PageName = "ProfilePage",
                    Title = "Modificar Perfil"
                },
                new Menu
                {
                    Icon ="ic_exit_to_app",
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
