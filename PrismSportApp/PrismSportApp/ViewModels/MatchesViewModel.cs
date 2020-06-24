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
        public IList<Match> Matches { get; set; } = new ObservableCollection<Match>();        
        public IList<League> Leagues { get; set; } = new ObservableCollection<League>();
        Competitions League { get; set; } = new Competitions();
        public string Title { get; set; }
        public string LogoHome { get; set; }
        public string LogoAway { get; set; }
        public bool Status { get; set; }
        public bool Loading { get; set; }
        Fixtures Fixture { get; set; } = new Fixtures();
        List<Teamm> Teamm { get; set; } = new List<Teamm>();
        public Links Links { get; set; } = new Links();
        public DelegateCommand GetLeaguesCommand { get; set; }        
        IApiServices apiServices;
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

    

        public MatchesViewModel(IApiServices api, IPageDialogService pageDialog, INavigationService navigationService):base(pageDialog, navigationService)
        {           
            apiServices = api;
            Title = "Games";
            GetLeaguesCommand = new DelegateCommand(async () => await GetLeagues());
            GetLeaguesCommand.Execute();

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
                this.Leagues = show.ToList();
            }
            catch (Exception ex)
            {                
                Debug.WriteLine($"Error en el metodo Leagues: {ex.Message}");
            }
        }
        async Task GetMatches(int id)
        {
            try
            {
                Loading = true;
                Status = false;
                RestService.For<IApiServices>(Links.url);
                var response1 = await apiServices.GetFixtures(id);
                Fixture = response1;
                this.Matches = Fixture.Matches;
                foreach (var item in Matches)
                {
                    var x = Teamm.Where(elemento => elemento.Id == item.HomeTeam.Id).ToList();
                    var y = Teamm.Where(elemento => elemento.Id == item.AwayTeam.Id).ToList();                    
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

