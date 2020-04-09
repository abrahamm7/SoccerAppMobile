using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using PrismSportApp.Models;
using PrismSportApp.Services;
using PrismSportApp.Views;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PrismSportApp.ViewModels
{
    public class MenuViewModel: BaseViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public DelegateCommand<string> onNavigate { get; set; }       
        public User User { get; set; } = new User();         
        ISqliteInterface sqlite;
        public MenuViewModel(INavigationService navigation, ISqliteInterface sqliteInterface, IPageDialogService pageDialog):base(pageDialog,navigation)
        {           
            onNavigate = new DelegateCommand<string>(Navigate);
            sqlite = sqliteInterface;
            var x = sqlite.GetConnection();
            var list = x.Query<User>("select * from User");
            User.Name = list.First().Name;
            
        }
        async void Navigate(string page)
        {
            await NavigationService.NavigateAsync(new Uri(page, UriKind.Relative));
        }      
    }
}
