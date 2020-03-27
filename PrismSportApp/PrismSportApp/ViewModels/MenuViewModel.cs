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
using System.Text;

namespace PrismSportApp.ViewModels
{
    public class MenuViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        INavigationService navigationService;
        public DelegateCommand<string> onNavigate { get; set; }
        public IEnumerable<League> LeaguesFavorites { get; set; } = new ObservableCollection<League>();
        public string Star { get; set; }
        public string Leagues { get; set; }
        public string Players { get; set; }
        public SQLiteConnection conn;
        public MenuViewModel(INavigationService navigation)
        {
            navigationService = navigation;
            onNavigate = new DelegateCommand<string>(Navigate);
            Star = "star.png";
            Players = "soccer.png";
            Leagues = "worldcup.png";
            conn = Xamarin.Forms.DependencyService.Get<ISqliteInterface>().GetConnection();
            GetLeagues();
        }
        async void Navigate(string page)
        {
            await navigationService.NavigateAsync(new Uri(page, UriKind.Relative));
        }
        async void GetLeagues()
        {
            LeaguesFavorites = conn.Query<League>("Select * from League");             
        }
    }
}
