using System;
using System.Collections.Generic;
using System.Text;

namespace PrismSportApp.Models
{
    public class LeagueStandings
    {
        public class Filters
        {
        }

        public class Area
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        public class Competition
        {
            public int id { get; set; }
            public Area area { get; set; }
            public string name { get; set; }
            public string code { get; set; }
            public string plan { get; set; }
            public DateTime lastUpdated { get; set; }
        }

        public class Season
        {
            public int id { get; set; }
            public string startDate { get; set; }
            public string endDate { get; set; }
            public int currentMatchday { get; set; }
            public object winner { get; set; }
        }

        public class Team
        {
            public int id { get; set; }
            public string name { get; set; }
            public string crestUrl { get; set; }
        }

        public class Table
        {
            public int position { get; set; }
            public Team team { get; set; }
            public int playedGames { get; set; }
            public int won { get; set; }
            public int draw { get; set; }
            public int lost { get; set; }
            public int points { get; set; }
            public int goalsFor { get; set; }
            public int goalsAgainst { get; set; }
            public int goalDifference { get; set; }
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
}
