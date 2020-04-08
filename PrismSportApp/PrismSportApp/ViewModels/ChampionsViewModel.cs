using Prism.Navigation;
using Prism.Services;
using PrismSportApp.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PrismSportApp.ViewModels
{
    public class ChampionsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;       
        public IList<League> Leagues { get; set; } = new ObservableCollection<League>();            
        public IList<Seasons> Seasons { get; set; } = new ObservableCollection<Seasons>();       
        Competitions League { get; set; } = new Competitions();         
        public string Crest { get; set; }
        public Links Links { get; set; } = new Links();
        INavigationService navigation;

        IPageDialogService dialogService;

        IApiServices apiServices;

        League Leaguess;
        public League LeagueSelected //Select element in picker//
        {
            get
            {
                return Leaguess;
            }
            set
            {
                Leaguess = value;
                if (Leaguess != null)
                {
                    switch (Leaguess.Id)
                    {
                        case 2002:
                            this.Crest = "Bundesliga.png";
                            break;

                        case 2021:
                            this.Crest = "PremierLeague.png";
                            break;
                    }
                    GetLeaguesChampions(Leaguess.Id);
                }
            }
        }

        public ChampionsViewModel(IApiServices api, INavigationService navigationService, IPageDialogService pageDialog)
        {
            navigation = navigationService;
            dialogService = pageDialog;
            apiServices = api;
            GetLeagues();
        }
        async void GetLeagues()
        {
            try
            {
                RestService.For<IApiServices>(Links.url);
                var response1 = await apiServices.GetLeagues();
                League = response1;
                var show = League.competitions.Where(elemento => elemento.Id == 2002 || elemento.Id == 2021);
                this.Leagues = show.ToList();
            }
            catch (Exception e)
            {
                await dialogService.DisplayAlertAsync("Advice", "Not connection to internet", "Ok");
                Debug.WriteLine($"Error: {e.Message}");
            }
        }
        async void GetLeaguesChampions(int param)
        {
            try
            {
                RestService.For<IApiServices>(Links.url);
                var response1 = await apiServices.GetLeagues(param);               
                var show = response1;                
                this.Seasons = show.seasons;
            }
            catch (Exception e)
            {
                await dialogService.DisplayAlertAsync("Advice", "Not connection to internet", "Ok");
                Debug.WriteLine($"Error: {e.Message}");
            }
        }
    }
}
