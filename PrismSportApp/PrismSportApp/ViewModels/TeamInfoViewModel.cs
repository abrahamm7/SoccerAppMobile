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

namespace PrismSportApp.ViewModels
{
    public class TeamInfoViewModel: INotifyPropertyChanged, INavigatedAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Table Table { get; set; } = new Table();
        
        public ICommand Save { get; set; }
       
        ISqliteInterface Sqlite;
        public void OnNavigatedFrom(INavigationParameters parameters)
        {
           
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            Table = parameters.GetValue<Table>("Team");           
        }
        public TeamInfoViewModel(ISqliteInterface sqliteInterface)
        {
            Save = new Command(AddTeam);
            Sqlite = sqliteInterface;          
        }

        async void AddTeam()
        {
            var x = Sqlite.GetConnection();
            //Table.Team.Name = TeamName;
            //Table.Team.CrestUrl= Logo;
            //conn.Insert(Table);
        }
    }
}
