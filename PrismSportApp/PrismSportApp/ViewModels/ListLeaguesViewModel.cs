using FFImageLoading.Work;
using Prism.Commands;
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
using System.Diagnostics;
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
        
        //Properties//
        public string TitlePage { get; set; }
        public bool Status { get; set; }
        public bool Loading { get; set; }

        //List model//
        public List<League> ListLeagues { get; set; } = new List<League>();

        //Models//
        public League LeagueModel { get; set; } = new League();
        Competitions Competitions { get; set; } = new Competitions();
        //Links for navigation//
        public Links Links { get; set; } = new Links();        

        //Commands//
        public DelegateCommand<object> Tap { get; set; }        
        public DelegateCommand GetLeaguesCommand { get; set; }        
        public DelegateCommand<string> SearchLeagueCommand { get; set; }   
        
        //Interfaces//
        INavigationService navigation;
        IApiServices apiServices;

        //Constructor//
        public ListLeaguesViewModel(IApiServices api, INavigationService navigationService)
        {
            apiServices = api;
            navigation = navigationService;  
            

            TitlePage = "Leagues";


            Tap = new DelegateCommand<object>(SelectLeague);            
            SearchLeagueCommand = new DelegateCommand<string>(SearchLeague);
            GetLeaguesCommand = new DelegateCommand(async() => await GetLeagues());
            GetLeaguesCommand.Execute();
            
        }

        //Method to retrieve Leagues//
        async Task GetLeagues()
        {
            try
            {
                Loading = true;

                Status = false;

                RestService.For<IApiServices>(Links.url);

                var obtainleagues = await apiServices.GetLeagues(); //Request to api//
                
                var findleague = obtainleagues.competitions.Where(elemento => elemento.Id == 2000 ||
                elemento.Id == 2001 ||
                elemento.Id == 2021 ||
                elemento.Id == 2015 ||
                elemento.Id == 2019 ||
                elemento.Id == 2017 ||
                elemento.Id == 2003 ||
                elemento.Id == 2002 ||
                elemento.Id == 2014).ToList();
                foreach (var item in findleague)
                {
                    switch (item.Id)
                    {
                        case 2000:                            
                            if (Device.RuntimePlatform == Device.UWP) 
                            {
                                item.EmblemUrl = "Assets/worldcup.png";
                               
                            }
                            else if (Device.RuntimePlatform == Device.Android || Device.RuntimePlatform == Device.iOS)
                            {
                                item.EmblemUrl = "worldcup.png";
                            }
                            break;
                        case 2001:                            
                            if (Device.RuntimePlatform == Device.UWP)
                            {
                                item.EmblemUrl = "Assets/uefachampions.png";

                            }
                            else if (Device.RuntimePlatform == Device.Android || Device.RuntimePlatform == Device.iOS)
                            {
                                item.EmblemUrl = "uefachampions.png";
                            }
                            break;
                        case 2021:                            
                            if (Device.RuntimePlatform == Device.UWP)
                            {
                                item.EmblemUrl = "Assets/PremierLeague.png";

                            }
                            else if (Device.RuntimePlatform == Device.Android || Device.RuntimePlatform == Device.iOS)
                            {
                                item.EmblemUrl = "PremierLeague.png";
                            }
                            break;
                        case 2017:                          
                            if (Device.RuntimePlatform == Device.UWP)
                            {
                                item.EmblemUrl = "Assets/portugal.png";

                            }
                            else if (Device.RuntimePlatform == Device.Android || Device.RuntimePlatform == Device.iOS)
                            {
                                item.EmblemUrl = "portugal.png";
                            }
                            break;
                        case 2019:                           
                            if (Device.RuntimePlatform == Device.UWP)
                            {
                                item.EmblemUrl = "Assets/SeriaA.png";

                            }
                            else if (Device.RuntimePlatform == Device.Android || Device.RuntimePlatform == Device.iOS)
                            {
                                item.EmblemUrl = "SeriaA.png";
                            }
                            break;
                        case 2003:                            
                            if (Device.RuntimePlatform == Device.UWP)
                            {
                                item.EmblemUrl = "Assets/eredivise.png";

                            }
                            else if (Device.RuntimePlatform == Device.Android || Device.RuntimePlatform == Device.iOS)
                            {
                                item.EmblemUrl = "eredivise.png";
                            }
                            break;
                        case 2015:                          
                            if (Device.RuntimePlatform == Device.UWP)
                            {
                                item.EmblemUrl = "Assets/ligue1.png";

                            }
                            else if (Device.RuntimePlatform == Device.Android || Device.RuntimePlatform == Device.iOS)
                            {
                                item.EmblemUrl = "ligue1.png";
                            }
                            break;
                        case 2014:                           
                            if (Device.RuntimePlatform == Device.UWP)
                            {
                                item.EmblemUrl = "Assets/LaLiga.png";

                            }
                            else if (Device.RuntimePlatform == Device.Android || Device.RuntimePlatform == Device.iOS)
                            {
                                item.EmblemUrl = "LaLiga.png";
                            }
                            break;                         
                        case 2002:
                            if (Device.RuntimePlatform == Device.UWP)
                            {
                                item.EmblemUrl = "Assets/Bundesliga.png";

                            }
                            else if (Device.RuntimePlatform == Device.Android || Device.RuntimePlatform == Device.iOS)
                            {
                                item.EmblemUrl = "Bundesliga.png";
                            }
                            break;
                    }
                }
                this.ListLeagues = findleague; //Fill list about competitions//

                Status = true;

                Loading = false;
            }
            catch (Exception e)
            {
                Status = false;
                Debug.WriteLine($"Error en el metodo Leagues: {e.Message}"); //Error message//
            }
        }

        //Method for select a competition//
        async void SelectLeague(object sender)
        {
            this.LeagueModel = sender as League; //Cast object//

            var search = Competitions.competitions.Where(elemento => elemento.Id == LeagueModel.Id).ToList();

            if (search.Any())
            {
                var parameters = new NavigationParameters();
                
                parameters.Add("League", LeagueModel);  //Parameters for passing to another page//
                
                await navigation.NavigateAsync(new Uri(NavConstants.DetailLeague , UriKind.RelativeOrAbsolute), parameters); //Navigate to another page//
            }
        }

        //Method for Search a competition by name//
        async void SearchLeague(string text)
        {
            if (text.Length >= 1)
            {                
                var suggestions = ListLeagues.Where(elem => elem.Name == text).ToList();

                ListLeagues.Clear();

                ListLeagues = suggestions;
            }
        }

    }
}
