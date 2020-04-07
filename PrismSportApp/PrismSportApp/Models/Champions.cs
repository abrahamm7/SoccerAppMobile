using System;
using System.Collections.Generic;
using System.Text;

namespace PrismSportApp.Models
{
    public class Champions
    {
        
    }
    public class Areas
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class CurrentSeasons
    {
        public int id { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public int currentMatchday { get; set; }
        public object winner { get; set; }
    }

    public class Winners
    {
        public int id { get; set; }
        public string name { get; set; }
        public string shortName { get; set; }
        public string tla { get; set; }
        public string crestUrl { get; set; }
    }

    public class Seasons
    {
        public int id { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public int? currentMatchday { get; set; }
        public Winners winner { get; set; }
    }

    public class LeagueChampions
    {
        public int id { get; set; }
        public Areas area { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public object emblemUrl { get; set; }
        public string plan { get; set; }
        public CurrentSeasons currentSeason { get; set; }
        public IList<Seasons> seasons { get; set; }
        public DateTime lastUpdated { get; set; }
    }
}
