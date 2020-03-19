using FFImageLoading.Svg.Forms;
using Prism.Commands;
using Prism.Navigation;
using PrismSportApp.Models;
using PrismSportApp.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PrismSportApp.ViewModels
{
    public class TeamInfoViewModel: INotifyPropertyChanged, INavigatedAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Teamm Teamm { get; set; } = new Teamm();
        public string TeamName { get; set; }
        public string Logo { get; set; }
        public string Won { get; set; }
        public string Draw { get; set; }
        public string PG { get; set; }
        public string Lost { get; set; }
        public ICommand Save { get; set; }
        public SvgCachedImage SvgCachedImage { get; set; } = new SvgCachedImage();
        public SQLiteConnection conn;
        public void OnNavigatedFrom(INavigationParameters parameters)
        {
           
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            this.TeamName = parameters.GetValue<string>("TeamName");
            this.Logo = parameters.GetValue<string>("Logo");
            this.Won = parameters.GetValue<string>("Win");
            this.Lost = parameters.GetValue<string>("Losts");
            this.Draw = parameters.GetValue<string>("Draws");
            this.PG = parameters.GetValue<string>("PG");
        }
        public TeamInfoViewModel()
        {
            Save = new Command(AddTeam);
            conn = DependencyService.Get<ISqliteInterface>().GetConnection();

        }

        async void AddTeam()
        {
            Teamm.Name = TeamName;
            Teamm.CrestUrl = Logo;
            conn.Insert(Teamm);
        }
    }
}
