using DLToolkit.Forms.Controls;
using Prism;
using Prism.Ioc;
using Prism.Services;
using Prism.Services.Dialogs;
using Prism.Unity;
using PrismSportApp.Models;
using PrismSportApp.Services;
using PrismSportApp.ViewModels;
using PrismSportApp.Views;
using SQLite;
using System;
using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.AppShortcuts;
using Plugin.AppShortcuts.Icons;

namespace PrismSportApp
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { FlowListView.Init(); }

       

        public ISqliteInterface sqlite = new SqliteModel();
        protected override void OnInitialized()
        {
            
            InitializeComponent();
            Shorts();
            if (Device.RuntimePlatform == Device.UWP)
            {
                NavigationService.NavigateAsync(new Uri(NavConstants.MasterMenu, UriKind.Relative));
            }
            else if (Device.RuntimePlatform == Device.Android || Device.RuntimePlatform == Device.iOS)
            {
                var x = sqlite.GetConnection();
                x.CreateTable<User>();
                x.CreateTable<Teamm>();
                var List = x.Query<User>("Select * From User");
                if (List.Any())
                {

                    NavigationService.NavigateAsync(new Uri(NavConstants.MasterMenu, UriKind.Absolute));
                }
                else
                {
                    NavigationService.NavigateAsync(new Uri(NavConstants.StartPage, UriKind.Relative));
                }
            }
           
           
        }
       
        async void Shorts()
        {
            var shortcut = new Shortcut()
            {
                Label = "Shortcut 1",
                Description = "Matches",
                Icon = new FavoriteIcon(),
                Uri = "asc://Xport/MatchesPage"
            };
            await CrossAppShortcuts.Current.AddShortcut(shortcut);
        }

        
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //Pages//
            
            containerRegistry.RegisterForNavigation<MenuPages,MenuViewModel>();
            containerRegistry.RegisterForNavigation<ListLeaguesPage,ListLeaguesViewModel>();           
            containerRegistry.RegisterForNavigation<TeamInfoPage,TeamInfoViewModel>();
            containerRegistry.RegisterForNavigation<TeamFavoritePage, TeamFavoriteViewModel>();         
            containerRegistry.RegisterForNavigation<DetailLeagueView,DetailLeagueViewModel>();
            containerRegistry.RegisterForNavigation<MatchesPage, MatchesViewModel>();
            containerRegistry.RegisterForNavigation<StartPageView, StartPageViewModel>();            
            containerRegistry.RegisterForNavigation<ChampionsView, ChampionsViewModel>();              
            containerRegistry.RegisterForNavigation<NavigationPage>();
            
            //Services//
            containerRegistry.Register<IApiServices, ApiService>();
            containerRegistry.Register<ISqliteInterface, SqliteModel>();
        }        

    }
}
