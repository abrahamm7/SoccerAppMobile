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
    public class TeamFavoriteViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public IList<Teamm> Teams { get; set; } = new ObservableCollection<Teamm>();
        public bool Visible { get; set; }
        public bool ListVisible { get; set; }      
        public string Logo { get; set; }
        public string Delete { get; set; }
        public ICommand Refresh { get; set; }
        public ICommand Tap { get; set; }
        public ICommand DeleteItem { get; set; }
        public SQLiteConnection conn;        

        public TeamFavoriteViewModel()
        {
            conn = DependencyService.Get<ISqliteInterface>().GetConnection();            
            Favorites();                     
            DeleteItem = new Command(Clear);
            Delete = "Delete";
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

       
        async void Clear(object sender)
        {
            var x = sender as Teamm;
            conn.Query<Teamm>($"Delete From Teamm Where Id = {x.Id}");
            Teams = conn.Query<Teamm>("SELECT * From Teamm").ToList();
            if (Teams.Count == 0)
            {
                Visible = true;
                ListVisible = false;
            }

        }
    }
}
