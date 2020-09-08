using Newtonsoft.Json;
using Plugin.FacebookClient;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using PrismSportApp.Models;
using PrismSportApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace PrismSportApp.ViewModels
{
    public class StartPageViewModel : BaseViewModel
    {
        //Models//
        public User User { get; set; } = new User();

        //Command//
        public DelegateCommand SignButton { get; set; }

        //Interfaces//
        ISqliteInterface sqliteInterface;
 
        //Constructor//
        public StartPageViewModel(INavigationService navigationService, IPageDialogService pageDialog, ISqliteInterface sqlite):base(pageDialog, navigationService)
        {                   
            sqliteInterface = sqlite;           

            SignButton = new DelegateCommand(async () => await LoginButton());
        }

        //Sign In button//
        async Task LoginButton() 
        {
            try
            {                
                if (!string.IsNullOrEmpty(User.Name) && !string.IsNullOrEmpty(User.Email) && User.Email.Contains("@") && User.Email.Contains(".com"))
                {
                    sqliteInterface.GetConnection().Insert(User); //Insert user into local db//


                    await NavigationService.NavigateAsync(new Uri(NavConstants.TabbedPage, UriKind.Relative)); //Navigate to another page//
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"{e.Message}"); //Error message//
            }
        }
    }

}
