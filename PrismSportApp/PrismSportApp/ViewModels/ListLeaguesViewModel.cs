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
        public string TitlePage { get; set; }
        public bool Status { get; set; }
        public bool Loading { get; set; }
        public List<League> Leagues { get; set; } = new List<League>();
        public League league { get; set; } = new League();
        Competitions League { get; set; } = new Competitions();
        public Links Links { get; set; } = new Links();        
        public DelegateCommand<object> Tap { get; set; }        
        public DelegateCommand GetLeaguesCommand { get; set; }        
        public DelegateCommand<string> SearchLeagueCommand { get; set; }        
        INavigationService navigation;
        IApiServices apiServices;

        public ListLeaguesViewModel(IApiServices api, INavigationService navigationService)
        {
            apiServices = api;
            navigation = navigationService;              
            Tap = new DelegateCommand<object>(SelectLeague);            
            TitlePage = "Leagues";
            SearchLeagueCommand = new DelegateCommand<string>(SearchLeague);
            GetLeaguesCommand = new DelegateCommand(async() => await GetLeagues());
            GetLeaguesCommand.Execute();
            
        }


        async Task GetLeagues()
        {
            try
            {
                Loading = true;
                Status = false;
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
                elemento.Id == 2014).ToList();
                foreach (var item in show)
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
                this.Leagues = show;
                Status = true;
                Loading = false;
            }
            catch (Exception e)
            {
                Status = false;
                Debug.WriteLine($"Error en el metodo Leagues: {e.Message}");
            }
        }
        async void SelectLeague(object sender)
        {            
            this.league = (League)sender;
            var search = League.competitions.Where(elemento => elemento.Id == league.Id);
            if (search.Any())
            {
                var parameters = new NavigationParameters();
                parameters.Add("League", league);               
                await navigation.NavigateAsync(new Uri(NavConstants.DetailLeague , UriKind.RelativeOrAbsolute), parameters);
            }
        }
        async void SearchLeague(string text)
        {
            if (text.Length >= 1)
            {                
                var suggestions = Leagues.Where(elem => elem.Name == text).ToList();
                Leagues.Clear();
                Leagues = suggestions;
            }

            

        }

    }
}
