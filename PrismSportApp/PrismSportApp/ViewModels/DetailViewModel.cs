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
using System.Threading.Tasks;

namespace PrismSportApp.ViewModels
{
    public class DetailViewModel: INotifyPropertyChanged ,INavigatedAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public League League;
        public Standings LeagueStandings { get; set; } = new Standings();
        public List<Table> Table { get; set; } = new List<Table>();
        public string NameLeague { get; set; }
        public int Code { get; set; }
        INavigationService navigation;

        IPageDialogService dialogService;

        IApiServices apiServices;
        public DetailViewModel(INavigationService navigationService, IApiServices api, IPageDialogService pageDialog)
        {
            navigation = navigationService;
            dialogService = pageDialog;
            apiServices = api;
            GetTable();


        }        


        public void OnNavigatedFrom(INavigationParameters parameters)
        {
           
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            this.NameLeague = parameters.GetValue<string>("Name");
            var key = parameters.GetValue<string>("LeagueId");
            this.Code = Convert.ToInt32(key);
        }

        async Task GetTable()
        {
            try
            {
                RestService.For<IApiServices>(Links.Url);

                var response = await apiServices.GetStandings(Code);
                LeagueStandings = response;
                //var worldcup = await apiServices.GetFixturesWorldCup();

                //var uefa = await apiServices.GetFixturesUefaChampions();

                this.Table = LeagueStandings.standings.First().table.ToList();

                //var show = League.competitions.Where(elemento => elemento.Id == 2000 || elemento.Id == 2001).ToList();

                //Fixture = worldcup;

                ////Fixture = uefa;

                //this.Matches = Fixture.Matches.Distinct().ToList();

                //this.CompetitionsLists = show;

            }
            catch (Exception ex)
            {

                Debug.WriteLine($"Error en el metodo Leagues: {ex.Message}");
            }

        }
    }
}
