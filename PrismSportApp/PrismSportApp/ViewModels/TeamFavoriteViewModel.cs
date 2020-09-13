using Prism.Commands;
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
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PrismSportApp.ViewModels
{
    public class TeamFavoriteViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //List//
        public List<Teamm> Teams { get; set; } = new List<Teamm>();

        //Properties//
        public bool Visible { get; set; }
        public bool ListVisible { get; set; }      
        public string Message { get; set; }
        public string Title { get; set; }

        //Command//
        public DelegateCommand<object> DeleteItem { get; set; }


        //Interface//
        ISqliteInterface sqlite;
        
        //Constructor//
        public TeamFavoriteViewModel(ISqliteInterface sqliteInterface)
        {
            sqlite = sqliteInterface;
            
            GetFavoriteTeams();

            //DeleteItem = new DelegateCommand<object>(Clear);
            
            Message = "Teams not found";
            Title = "Favorite Teams";
        }

        //Get favorites teams from local db//
        async Task GetFavoriteTeams()
        {
            var teamslist = sqlite.GetConnection().Query<Teamm>("SELECT * From Teamm");
           
            if (teamslist.Count == 0)
            {
                Visible = true;
                ListVisible = false;
            }
            else
            {
                Teams = teamslist; //Fill list//
               
                Visible = false;
                ListVisible = true;

            }
        }

       
        //async void Clear(object sender)
        //{
        //    var conn = sqlite.GetConnection();
        //    var x = sender as Teamm;
        //    conn.Query<Teamm>($"Delete From Teamm Where Id = {x.Id}");
        //    Teams = conn.Query<Teamm>("SELECT * From Teamm").ToList();
        //    if (Teams.Count == 0)
        //    {
        //        Visible = true;
        //        ListVisible = false;
        //    }

        //}
    }
}
