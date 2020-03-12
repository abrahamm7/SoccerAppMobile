using Prism;
using Prism.Ioc;
using Prism.Unity;
using PrismSportApp.ViewModels;
using PrismSportApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrismSportApp
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();
            //NavigationService.NavigateAsync("MatchesPage");
            NavigationService.NavigateAsync(new Uri(NavConstants.TabMenu, UriKind.Absolute));
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //Pages//
            containerRegistry.RegisterForNavigation<MatchesPage, MatchViewModel>();
            containerRegistry.RegisterForNavigation<TeamPage, TeamPageViewModel>();
            containerRegistry.RegisterForNavigation<MenuPages>();


            //Services//
            containerRegistry.Register<IApiServices, ApiService>();
        }

       
    }
}
