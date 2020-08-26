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
    public class StartPageViewModel : BaseViewModel
    {
        public User User { get; set; } = new User();
        public DelegateCommand SignButton { get; set; }
        ISqliteInterface sqliteInterface;
        public StartPageViewModel(INavigationService navigationService, IPageDialogService pageDialog, ISqliteInterface sqlite):base(pageDialog, navigationService)
        {                   
            sqliteInterface = sqlite;           
            SignButton = new DelegateCommand(Entries);           
        }

        async void Entries()
        {
            if (!string.IsNullOrEmpty(User.Name) && !string.IsNullOrEmpty(User.Email) && User.Email.Contains("@") && User.Email.Contains(".com"))
            {
                var x = sqliteInterface.GetConnection();
                x.Insert(User);
                await NavigationService.NavigateAsync(new Uri(NavConstants.MasterMenu, UriKind.Absolute));
            }
        }
        
        
    }
}
