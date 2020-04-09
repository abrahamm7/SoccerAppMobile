using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using PrismSportApp.Models;
using PrismSportApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace PrismSportApp.ViewModels
{
    public class StartPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public User User { get; set; } = new User();
        public DelegateCommand SignButton { get; set; }
    
        INavigationService navigation;
        IPageDialogService dialogService;
        ISqliteInterface sqliteInterface;
        public StartPageViewModel(INavigationService navigationService, IPageDialogService pageDialog, ISqliteInterface sqlite)
        {
            navigation = navigationService;
            dialogService = pageDialog;           
            sqliteInterface = sqlite;           
            SignButton = new DelegateCommand(Entries);           
        }

        async void Entries()
        {
            if (string.IsNullOrEmpty(User.Name) || string.IsNullOrEmpty(User.Email) || !User.Email.Contains("@") || !User.Email.Contains(".com"))
            {
                await dialogService.DisplayAlertAsync("Advice","Empty fields","ok");
            }
            else
            {
                var x = sqliteInterface.GetConnection();
                x.Insert(User);                
                await navigation.NavigateAsync(new Uri(NavConstants.MasterMenu, UriKind.Absolute));
                
            }
        }
        
        
    }
}
