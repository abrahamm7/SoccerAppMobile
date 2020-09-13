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
using Prism.Commands;

namespace PrismSportApp.ViewModels
{
    public class MatchesViewModel: BaseViewModel
    {              

        //List of leagues and matches//   
        public IList<League> Leagues { get; set; } = new ObservableCollection<League>();
        public IList<Match> Matches { get; set; } = new ObservableCollection<Match>();

        //Properties//
        public string Title { get; set; }
        public string LogoHome { get; set; }
        public string LogoAway { get; set; }
        public bool Status { get; set; }
        public bool Loading { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }


        //Models//
        List<Teamm> Teamm { get; set; } = new List<Teamm>();
        League Competition;

        //Link for navigation//
        public Links Links { get; set; } = new Links();

        //Command//
        public DelegateCommand GetLeaguesCommand { get; set; }        
        
        //Interfaces//
        IApiServices apiServices;

        //Select element in picker//
        public League LeagueSelected 
        {
            get
            {
                return Competition;
            }
            set
            {
                Competition = value;
                if (Competition != null)
                {
                   GetMatches(Competition.Id);
                }
            }
        }

    
        //Constructor//
        public MatchesViewModel(IApiServices api, IPageDialogService pageDialog, INavigationService navigationService):base(pageDialog, navigationService)
        {           
            apiServices = api;

            Title = "Games";

            GetLeaguesCommand = new DelegateCommand(async () => await GetLeagues());
            GetLeaguesCommand.Execute();

        }

        
        //Retrieve data about competitions//
        async Task GetLeagues()
        {
            try
            {
                RestService.For<IApiServices>(Links.url);

                var competitions = await apiServices.GetLeagues();
               
                var show = competitions.competitions.Where(elemento => elemento.Id == 2000 ||
                elemento.Id == 2001 ||
                elemento.Id == 2021 ||
                elemento.Id == 2015 ||
                elemento.Id == 2019 ||
                elemento.Id == 2017 ||
                elemento.Id == 2003 ||
                elemento.Id == 2002 ||
                elemento.Id == 2014).ToList();
                this.Leagues = show;
            }
            catch (Exception ex)
            {                
                Debug.WriteLine($"Error en el metodo Leagues: {ex.Message}");
            }
        }

        //Retrieve data about matches for selected league//
        async Task GetMatches(int id)
        {
            try
            {
                Loading = true;
                Status = false;
                RestService.For<IApiServices>(Links.url);

                var fixtures = await apiServices.GetFixtures(id);

                Matches = fixtures.Matches; //Fill list of fixtures//

                foreach (var item in fixtures.Matches)
                {
                    Teamm.Where(element => element.Id == item.HomeTeam.Id);

                    Teamm.Where(element => element.Id == item.AwayTeam.Id);                    
                }              
                Loading = false;
                Status = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error en el metodo Matches: {ex.Message}");
                Loading = true;
                Status = false;
            }

        }        
     
    }
}

