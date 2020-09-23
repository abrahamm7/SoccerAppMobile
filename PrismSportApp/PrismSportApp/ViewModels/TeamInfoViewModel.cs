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
    }
}
