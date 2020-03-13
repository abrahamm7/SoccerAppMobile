using Prism.Commands;
using Prism.Navigation;
using PrismSportApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PrismSportApp.ViewModels
{
    public class MenuViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        INavigationService navigationService;
        public DelegateCommand<string> onNavigate { get; set; }
        public MenuViewModel(INavigationService navigation)
        {
            navigationService = navigation;
            onNavigate = new DelegateCommand<string>(Navigate);
        }
        async void Navigate(string page)
        {
            await navigationService.NavigateAsync(new Uri(page, UriKind.Relative));
        }
    }
}
