using Prism.Navigation;
using Prism.Services;
using PrismSportApp.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace PrismSportApp.ViewModels
{
    public class MatchViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<League> CompetitionsLists { get; set; } = new ObservableCollection<League>();
        public ObservableCollection<Match> Matches { get; set; } = new ObservableCollection<Match>();
        Fixtures Fixture { get; set; } = new Fixtures();
        Competitions League { get; set; } = new Competitions();
        INavigationService navigation;
        IPageDialogService dialogService;
        IApiServices apiServices;
        public MatchViewModel(IApiServices api, INavigationService navigationService, IPageDialogService pageDialog)
        {
            navigation = navigationService;
            dialogService = pageDialog;
            apiServices = api;
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                Messages();
            }
            else
            {
                GetMatches();
            }
            
        }

        async Task GetMatches()
        {
            try
            {
                RestService.For<IApiServices>(Links.Url);
                var response = await apiServices.GetFixturesWorldCup();
                var response1 = await apiServices.GetLeagues();
                League = response1;
                Fixture = response;
                this.Matches = Fixture.Matches;
                this.CompetitionsLists = League.competitions;

            }
            catch (Exception ex)
            {

                Debug.WriteLine($"Error en el metodo Leagues: {ex.Message}");
            }

        }

        void Messages()
        {
            dialogService.DisplayAlertAsync("Error", "Check your connection to internet", "ok");
        }
    }
}

