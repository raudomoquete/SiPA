using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiPA.Prism.ViewModels
{
    public class ViewModelBase : BindableBase, IInitialize, INavigationAware, IDestructible
    {
        protected INavigationService NavigationService { get; private set; }

        private string _title;
        private string _title2;
        private string _title3;
        private string _title4;
        private string _title5;




        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        public string Title2
        {
            get { return _title2; }
            set { SetProperty(ref _title2, value); }
        }
        public string Title3
        {
            get { return _title3; }
            set { SetProperty(ref _title3, value); }
        }
        public string Title4
        {
            get { return _title4; }
            set { SetProperty(ref _title4, value); }
        }
        public string Title5
        {
            get { return _title5; }
            set { SetProperty(ref _title5, value); }
        }

        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public virtual void Initialize(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public virtual void Destroy()
        {

        }
    }
}
