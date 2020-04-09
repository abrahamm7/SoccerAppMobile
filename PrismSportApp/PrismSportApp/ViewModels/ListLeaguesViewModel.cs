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
        public string Logo { get; set; }
        public string TitlePage { get; set; }
        public IEnumerable<League> Leagues { get; set; } = new ObservableCollection<League>();
        public League league { get; set; } = new League();
        Competitions League { get; set; } = new Competitions();
        public Links Links { get; set; } = new Links();        
        public DelegateCommand<object> Tap { get; set; }        
        public DelegateCommand GetLeaguesCommand { get; set; }        

        INavigationService navigation;

        IPageDialogService dialogService;

        IApiServices apiServices;

        public ListLeaguesViewModel(IApiServices api, INavigationService navigationService, IPageDialogService pageDialog)
        {
            apiServices = api;
            navigation = navigationService;
            dialogService = pageDialog;                    
            Tap = new DelegateCommand<object>(SelectLeague);            
            TitlePage = "Leagues";
            GetLeaguesCommand = new DelegateCommand(async() => await GetLeagues());
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
                foreach (var item in show)
                {
                    switch (item.Id)
                    {
                        case 2000:
                            item.EmblemUrl = "worldcup.png";
                            break;
                        case 2001:
                            item.EmblemUrl = "uefachampions.png";
                            break;
                        case 2021:
                            item.EmblemUrl = "PremierLeague.png";
                            break;
                        case 2017:
                            item.EmblemUrl = "portugal.png";
                            break;
                        case 2019:
                            item.EmblemUrl = "SeriaA.png";
                            break;
                        case 2003:
                            item.EmblemUrl = "eredivise.png";
                            break;
                        case 2015:
                            item.EmblemUrl = "ligue1.png";
                            break;
                        case 2014:
                            item.EmblemUrl = "LaLiga.png";
                            break;
                        case 2002:
                            item.EmblemUrl = "Bundesliga.png";
                            break;
                    }
                }
                this.Leagues = show;
             
               
            }
            catch (Exception e)
            {
                await dialogService.DisplayAlertAsync("Advice", "Not connection to internet", "Ok");
                Debug.WriteLine(e.Message);
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
                await navigation.NavigateAsync(new Uri(NavConstants.DetailLeague , UriKind.Relative), parameters);
            }
        }
    }
}
