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
        protected override void OnInitialized()
        {
            InitializeComponent();
            //NavigationService.NavigateAsync("MatchesPage");
            NavConstants nav = new NavConstants();
            NavigationService.NavigateAsync(new Uri(nav.MasterMenu, UriKind.Absolute));
            conn = Xamarin.Forms.DependencyService.Get<ISqliteInterface>().GetConnection();
            conn.CreateTable<Teamm>();
            conn.CreateTable<League>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //Pages//
            containerRegistry.RegisterForNavigation<TeamPage, TeamPageViewModel>();
            containerRegistry.RegisterForNavigation<MenuPages,MenuViewModel>();
            containerRegistry.RegisterForNavigation<ListLeaguesPage,ListLeaguesViewModel>();           
            containerRegistry.RegisterForNavigation<TeamInfoPage,TeamInfoViewModel>();
            containerRegistry.RegisterForNavigation<TeamFavoritePage, TeamFavoriteViewModel>();
            containerRegistry.RegisterForNavigation<MenuStandings>();
            containerRegistry.RegisterForNavigation<DetailLeagueView,DetailLeagueViewModel>();
            containerRegistry.RegisterForNavigation<MatchesPage, MatchesViewModel>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            
            //Services//
            containerRegistry.Register<IApiServices, ApiService>();
        }

        //protected override void OnStart()
        //{
        //    if (Connectivity.NetworkAccess != NetworkAccess.Internet)
        //    {
        //        Message(dialog);
        //    }
        //}
        
        //async void Message(IPageDialogService pageDialog)
        //{
        //    dialog = pageDialog;
        //    await dialog.DisplayAlertAsync("Advice", $"Not connection to internet", "Ok");
        //}

    }
}
