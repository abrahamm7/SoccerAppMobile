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
using System.Xml.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;
using Prism.Services.Dialogs;
using Prism.Services;
using System.Threading.Tasks;
using System.Diagnostics;
using Prism.Common;
using Refit;

namespace PrismSportApp.ViewModels
{
    public class TeamInfoViewModel: INotifyPropertyChanged, INavigatedAware
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //Models//
        public Table Table { get; set; } = new Table();
        public Links Links { get; set; } = new Links();
        public List<Article> FeedNews { get; set; } = new List<Article>();
       
        //Commands//
        public DelegateCommand Follow { get; set; }
        public DelegateCommand UnFollow { get; set; }

        //Properties//   
        public bool UnFollowVisible { get; set; }
        public bool FollowVisible { get; set; }

       
        //Interfaces//
        public ISqliteInterface Sqlite;
        public IApiServices apiServices;
        
        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }


        //Parameters to receive//
        public void OnNavigatedTo(INavigationParameters parameters)
        {
            Table = parameters.GetValue<Table>("Team");
        }

        //Constructor//
        public TeamInfoViewModel(ISqliteInterface sqliteInterface, IApiServices api)
        {
            Sqlite = sqliteInterface;
            apiServices = api;
            GetNews();


            //GetTeams();
            //Follow = new DelegateCommand(SetFavorite);
            //UnFollow = new DelegateCommand(RemoveFavorite);
      
        }
        
        async Task GetNews()
        {
            try
            {
                RestService.For<IApiServices>(Links.url);
                var news = await apiServices.GetNews("Barca");
                FeedNews = news.Articles.ToList();
                
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }
        //async void GetTeams()
        //{
        //    try
        //    {
        //        var teamswap = Table.Team.Name;

        //        var localdb = Sqlite.GetConnection();
        //        var retrieve = localdb.Query<Teamm>($"Select * from Teamm where Name = '{teamswap}'");
        //        var obtainteam = retrieve.Where(elem => elem.Name == Table.Team.Name).ToList(); //Retrieve data from local db//

        //        if (obtainteam.Count > 0)
        //        {
        //            UnFollowVisible = true;
        //            FollowVisible = false;
        //        }
        //        else
        //        {
        //            UnFollowVisible = false;
        //            FollowVisible = true;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Debug.WriteLine($"{e.Message}");
        //    }
        //}

        ////Save Team into local db//
        //async void SetFavorite()  
        //{
        //    try
        //    {
        //        var obtainteams = Sqlite.GetConnection().Query<Teamm>($"Select * from Teamm where Name = '{Table.Team.Name}'"); //Retrieve data from local db//

        //        if (obtainteams.Count == 0)
        //        {
        //            Sqlite.GetConnection().Insert(Table.Team);  //Insert team into local db//           
        //            UnFollowVisible = true;
        //            FollowVisible = false;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Debug.WriteLine($"{e.Message}");
        //    }
        //}

        ////Delete team from local db//
        //async void RemoveFavorite()
        //{
        //    try
        //    {

        //        Sqlite.GetConnection().Query<Teamm>($"Delete from Teamm where Name = '{Table.Team.Name}'"); //Delete data from local db//
        //        UnFollowVisible = false;
        //        FollowVisible = true;
        //    }
        //    catch (Exception e)
        //    {
        //        Debug.WriteLine($"{e.Message}");
        //    }
        //}
    }
}
