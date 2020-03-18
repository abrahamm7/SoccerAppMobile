using Prism.Navigation;
using PrismSportApp.Models;
using PrismSportApp.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PrismSportApp.ViewModels
{
    public class TeamFavoriteViewModel: INotifyPropertyChanged, INavigatedAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Teamm> Teams { get; set; } = new ObservableCollection<Teamm>();
        public bool Visible { get; set; }
        public bool ListVisible { get; set; }
        public bool StateButton { get; set; }
        public bool State { get; set; }
        public string Logo { get; set; }
        public ICommand Refresh { get; set; }
        public ICommand Tap { get; set; }
        public SQLiteConnection conn;
        public void OnNavigatedFrom(INavigationParameters parameters)
        {
         
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
           
        }

        public TeamFavoriteViewModel()
        {
            conn = DependencyService.Get<ISqliteInterface>().GetConnection();            
            Favorites();
            StateButton = false;
            Tap = new Command(TapFrame);
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
                foreach (var item in x)
                {
                    Teams.Add(item);
                }

            }

        }

        async void TapFrame()
        {
            StateButton = true;
        }
    }
}
