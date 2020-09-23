using System;
using System.Collections.Generic;
using System.Text;

namespace PrismSportApp.Models
{
    public class Links
    {
        public string url { get; set; }
        public string matches { get; set; }
        public string Champions { get; set; }
        public string Bundesliga { get; set; }       
        public string Leagues { get; set; }
        public string LeaguesChampions { get; set; }
        public string Team { get; set; }
        public string LeagueStan { get; set; }
        public string NewsApi { get; set; }
        public Links(int id)
        {
            url = "https://www.football-data.org/";
            matches = $"http://api.football-data.org/v2/competitions/{id}/matches";                     
            Team = $"http://api.football-data.org/v2/teams/{id}";
            LeagueStan = $"https://api.football-data.org/v2/competitions/{id}/standings?standing";
            LeaguesChampions = $"http://api.football-data.org/v2/competitions/{id}";
           
        }
        public Links()
        {
            url = "https://www.football-data.org/";
            matches = $"http://api.football-data.org/v2/competitions/2000/matches?matchday";
            Champions = $"http://api.football-data.org/v2/competitions/2001/matches?matchday";
            Bundesliga = $"http://api.football-data.org/v2/competitions/2002/matches?matchday";
            Leagues = $"http://api.football-data.org/v2/competitions";
        }
        public Links(string name)
        {
            NewsApi = $"https://newsapi.org/v2/everything?q={name}&apiKey=2b6d74babe00414b91370d5e0bd85b35";
        }
       

       
    }
    
}
