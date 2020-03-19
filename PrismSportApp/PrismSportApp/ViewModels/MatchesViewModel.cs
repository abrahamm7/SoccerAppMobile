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

namespace PrismSportApp.ViewModels
{
    public class MatchesViewModel: INotifyPropertyChanged, INavigatedAware
    {
        #region Class
        public event PropertyChangedEventHandler PropertyChanged;     
        public ObservableCollection<Match> Matches { get; set; } = new ObservableCollection<Match>();
        Fixtures Fixture { get; set; } = new Fixtures();  
        public int code { get; set; } 
        public Links Links { get; set; } = new Links();
        INavigationService navigation;

        IPageDialogService dialogService;
        
        IApiServices apiServices;
        #endregion

        #region Commands and Properties
        public ICommand Selected { get; set; }
        #endregion

        

        #region Constructor
        public MatchesViewModel(IApiServices api, INavigationService navigationService, IPageDialogService pageDialog)
        {
            navigation = navigationService;
            dialogService = pageDialog;
            apiServices = api;
            
        }
        #endregion


        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            var navigationMode = parameters.GetNavigationMode();
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {

            var key = parameters.GetValue<string>("LeagueId");
            this.code = Convert.ToInt32(key);
            GetMatches(Convert.ToInt32(code));
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

        
    }
}

