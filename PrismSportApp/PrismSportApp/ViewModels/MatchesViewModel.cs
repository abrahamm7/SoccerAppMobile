using Prism.Navigation;
using Prism.Services;
using PrismSportApp.Models;
using Refit;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using System.Windows.Input;
using Xamarin.Forms;
using System.Runtime.CompilerServices;

namespace PrismSportApp.ViewModels
{
    public class MatchesViewModel: INotifyPropertyChanged
    {        
        #region Class
        public event PropertyChangedEventHandler PropertyChanged;     
        public IList<Match> Matches { get; set; } = new ObservableCollection<Match>();        
        public IList<League> Leagues { get; set; } = new ObservableCollection<League>();
        Competitions League { get; set; } = new Competitions();
        Fixtures Fixture { get; set; } = new Fixtures();         
        public Links Links { get; set; } = new Links();
        INavigationService navigation;

        IPageDialogService dialogService;
        
        IApiServices apiServices;
        #endregion

        #region Commands and Properties
        League Leaguess;
        Match Match;
        public League LeagueSelected //Select element in picker//
        {
            get
            {
                return Leaguess;
            }
            set
            {
                Leaguess = value;
                if (Leaguess!= null)
                {
                   GetMatches(Leaguess.Id);
                }
            }
        }

       
        #endregion

        #region Constructor
        public MatchesViewModel(IApiServices api, INavigationService navigationService, IPageDialogService pageDialog)
        {
            navigation = navigationService;
            dialogService = pageDialog;
            apiServices = api;            
            GetLeagues();
            
        }
        #endregion

        #region Metodos
        async void GetLeagues()
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
                this.Leagues = show.ToList();
            }
            catch (Exception ex)
            {
                await dialogService.DisplayAlertAsync("Advice", "Not connection to internet", "Ok");
                Debug.WriteLine($"Error en el metodo Leagues: {ex.Message}");
            }
        }
        async Task GetMatches(int id)
        {
            try
            {
                RestService.For<IApiServices>(Links.url);
                var response1 = await apiServices.GetFixtures(id);
                Fixture = response1;
                this.Matches = Fixture.Matches;              

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error en el metodo Matches: {ex.Message}");
            }

        }        
        #endregion
    }
}

