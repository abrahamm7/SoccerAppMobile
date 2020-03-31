using Prism.Navigation;
using Prism.Services;
using PrismSportApp.Models;
using PrismSportApp.Services;
using Refit;
using SQLite;
using Stormlion.PhotoBrowser;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PrismSportApp.ViewModels
{
    public class ListLeaguesViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;       
        public string Logo { get; set; }
        public string TitlePage { get; set; }
        public IEnumerable<League> Leagues { get; set; } = new ObservableCollection<League>();
        public League league { get; set; } = new League();
        Competitions League { get; set; } = new Competitions();
        public Links Links { get; set; } = new Links();        
        public ICommand Tap { get; set; }        

        INavigationService navigation;

        IPageDialogService dialogService;

        IApiServices apiServices;

        ISqliteInterface sqlite;



        public ListLeaguesViewModel(IApiServices api, ISqliteInterface sqliteInterface, INavigationService navigationService, IPageDialogService pageDialog)
        {
            apiServices = api;
            navigation = navigationService;
            dialogService = pageDialog;
            sqlite = sqliteInterface;           
            Tap = new Command(SelectLeague);            
            TitlePage = "Leagues";
            GetLeagues();
            
        }


        async Task GetLeagues()
        {
            try
            {
                RestService.For<IApiServices>(Links.url);
                var response1 = await apiServices.GetLeagues();
                League = response1;               
                var show = League.competitions.Where(elemento => elemento.Id == 2000 ||
                elemento.Id == 2001 ||
                elemento.Id == 2021 ||
                elemento.Id == 2015 ||
                elemento.Id == 2019 ||
                elemento.Id == 2017 ||
                elemento.Id == 2003 ||
                elemento.Id == 2002 ||
                elemento.Id == 2014);
                this.Leagues = show;
                var x = show.First().Id;
                switch (x) //Check code
                {
                    case 2001:
                        Logo = "LaLiga.png";
                        break;

                    case 2021:
                        Logo = "PremierLeague.png";
                        break;
                    case 2017:
                        Logo = "Bundesliga.png";
                        break;
                }
            }
            catch (Exception e)
            {
                await dialogService.DisplayAlertAsync("Advice", "Not connection to internet", "Ok");
            }
        }
        async void SelectLeague(object sender)
        {            
            this.league = (League)sender;
            var search = League.competitions.Where(elemento => elemento.Id == league.Id);
            if (search.Any())
            {
                var parameters = new NavigationParameters();
                parameters.Add("LeagueId", league.Id);
                parameters.Add("Name", league.Name);
                await navigation.NavigateAsync(new Uri(NavConstants.DetailLeague , UriKind.Relative), parameters);
            }
        }

    

        
    }
}
