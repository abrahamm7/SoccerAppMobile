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
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrismSportApp
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }
        
        public SQLiteConnection conn;
        public ISqliteInterface sqlite = new SqliteModel();
        protected override void OnInitialized()
        {
            InitializeComponent();            
            var x = sqlite.GetConnection();            
            x.CreateTable<Teamm>();
            x.CreateTable<League>();           
            NavigationService.NavigateAsync(new Uri(NavConstants.StartPage, UriKind.Relative));
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
            containerRegistry.RegisterForNavigation<NavigationPage>();
            
            //Services//
            containerRegistry.Register<IApiServices, ApiService>();
            containerRegistry.Register<ISqliteInterface, SqliteModel>();
        }        

    }
}
