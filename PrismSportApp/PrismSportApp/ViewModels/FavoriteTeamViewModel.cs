using Prism.Navigation;
using PrismSportApp.Models;
using PrismSportApp.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace PrismSportApp.ViewModels
{
    public class FavoriteTeamViewModel: INotifyPropertyChanged, INavigatedAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public List<Teamm> Teams { get; set; } = new List<Teamm>();
        public bool Visible;
        public bool ListVisible;
        public SQLiteConnection conn;
        public void OnNavigatedFrom(INavigationParameters parameters)
        {
         
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
           
        }

        public FavoriteTeamViewModel()
        {
            conn = DependencyService.Get<ISqliteInterface>().GetConnection();
            Favorites();
        }

        async void Favorites()
        {
            var x = conn.Query<Teamm>("SELECT * From Teamm");
            if (x.Count == 0)
            {
                Visible = true;
                ListVisible = false;
            }
            else
            {
                Visible = false;
                ListVisible = true;
                Teams.Add(x.First());
                
            }
                     
        }
    }
}
