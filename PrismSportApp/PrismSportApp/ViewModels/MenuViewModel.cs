using Prism.Commands;
using Prism.Navigation;
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
    public class MenuViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        INavigationService navigationService;
        public DelegateCommand<string> onNavigate { get; set; }       
        public User User { get; set; } = new User();        
        public ICommand Tap { get; set; }   
        ISqliteInterface sqlite;
        public MenuViewModel(INavigationService navigation, ISqliteInterface sqliteInterface)
        {
            navigationService = navigation;
            onNavigate = new DelegateCommand<string>(Navigate);
            sqlite = sqliteInterface;
            var x = sqlite.GetConnection();
            var list = x.Query<User>("select * from User");
            User.Name = list.First().Name;
            
        }
        async void Navigate(string page)
        {
            await navigationService.NavigateAsync(new Uri(page, UriKind.Relative));
        }      
    }
}
