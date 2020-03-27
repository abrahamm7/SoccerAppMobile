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
        public League league { get; set; } = new League();
        public Competitions League { get; set; } = new Competitions();
        public IList<League> LeaguesFavorites { get; set; } = new ObservableCollection<League>();
        public ICommand Tap { get; set; }
        public string Star { get; set; }
        public bool State { get; set; }
        public bool StateList { get; set; }
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
            //Tap = new Command(SelectLeague);
            GetLeagues();
        }
        async void Navigate(string page)
        {
            await navigationService.NavigateAsync(new Uri(page, UriKind.Relative));
        }
        async void GetLeagues()
        {
            var x = conn.Query<League>("Select * from League").ToList();
            if (x.Count == 0)
            {
                State = true;
                StateList = false;
                
            }
            else
            {
                State = false;
                StateList = true;
                LeaguesFavorites = conn.Query<League>("Select * from League").ToList();
            }
                        
        }

        //async void SelectLeague(object sender)
        //{
        //    NavConstants navConstants = new NavConstants();
        //    this.league = (League)sender;
        //    var search = League.competitions.Where(elemento => elemento.Name == league.Name);
        //    if (search.Any())
        //    {
        //        var parameters = new NavigationParameters();
        //        parameters.Add("LeagueId", league.Id);
        //        parameters.Add("Name", league.Name);
        //        await navigationService.NavigateAsync(new Uri(navConstants.DetailLeague, UriKind.Relative), parameters);
        //    }
        //}
    }
}
