using Prism.Navigation;
using Prism.Services;
using PrismSportApp.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace PrismSportApp.ViewModels
{
    public class DetailLeagueViewModel: INotifyPropertyChanged ,INavigatedAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public League League { get; set; } = new League();
        public Standings LeagueStandings { get; set; } = new Standings();
        public IEnumerable<Table> Table { get; set; } = new ObservableCollection<Table>();
        public Teamm Teamm { get; set; } = new Teamm();
        public Table TeamTable { get; set; } = new Table();
        public Links Links { get; set; } = new Links();
        public string NameLeague { get; set; }        
        public int Code { get; set; }
        public string Logo { get; set; }

        public ICommand Tap { get; set; }
        INavigationService navigation;

        IPageDialogService dialogService;

        IApiServices apiServices;
        public DetailLeagueViewModel(INavigationService navigationService, IApiServices api, IPageDialogService pageDialog)
        {
            navigation = navigationService;
            dialogService = pageDialog;
            apiServices = api;            
            Tap = new Command(SelectTeam);
        }        


        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            League = parameters.GetValue<League>("League");                     
            GetTable(League.Id);
        }

        async Task GetTable(int param)
        {           
            try
            {
                RestService.For<IApiServices>(Links.url);
                var response = await apiServices.GetStandings(param);
                LeagueStandings = response;                          
                this.Table = LeagueStandings.standings.First().table;                
            }
            catch (Exception ex)
            {

                Debug.WriteLine($"Error en el metodo Table: {ex.Message}");
            }

        }

        async void SelectTeam(object sender)
        {            
            TeamTable = (Table)sender;
            var parameters = new NavigationParameters();
            parameters.Add("Team", TeamTable);                            
            await navigation.NavigateAsync(new Uri(NavConstants.TeamInfo, UriKind.Relative), parameters);
        }
    }
}
