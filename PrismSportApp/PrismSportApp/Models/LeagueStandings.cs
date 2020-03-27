using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace PrismSportApp.Models
{
    public class LeagueStandings
    {
        
    }
    public class Filterss
    {
    }

    public class Areaa
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Competitionn
    {
        public int id { get; set; }
        public Area area { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string plan { get; set; }
        public DateTime lastUpdated { get; set; }
    }

    public class Seasonn
    {
        public int id { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public int currentMatchday { get; set; }
        public object winner { get; set; }
    }

    public class Teamm
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string CrestUrl { get; set; }
    }

    public class Table: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public int Position { get; set; }       
        public Teamm Team { get; set; }
        public int PlayedGames { get; set; }
        public int Won { get; set; }
        public int Draw { get; set; }
        public int Lost { get; set; }
        public int Points { get; set; }
        public int GoalsFor { get; set; }
        public int GoalsAgainst { get; set; }
        public int GoalDifference { get; set; }        

    }

    public class Standing
    {
        public string stage { get; set; }
        public string type { get; set; }
        public object group { get; set; }
        public IList<Table> table { get; set; }
    }

    public class Standings
    {
        public Filters filters { get; set; }
        public Competition competition { get; set; }
        public Season season { get; set; }
        public IList<Standing> standings { get; set; }
    }
}
