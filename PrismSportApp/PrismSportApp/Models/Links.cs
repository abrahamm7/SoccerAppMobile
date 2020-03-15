using System;
using System.Collections.Generic;
using System.Text;

namespace PrismSportApp.Models
{
    public class Links
    {
        public string url { get; set; }
        public string WorldCup { get; set; }
        public string Champions { get; set; }
        public string Bundesliga { get; set; }
        public string Leagues { get; set; }
        public string Team { get; set; }
        public string LeagueStan { get; set; }
        public Links(int id)
        {
            url = "https://www.football-data.org/";
            WorldCup = $"http://api.football-data.org/v2/competitions/2000/matches?matchday";
            Champions = $"http://api.football-data.org/v2/competitions/2001/matches?matchday";
            Bundesliga = $"http://api.football-data.org/v2/competitions/2002/matches?matchday";
            Leagues = $"http://api.football-data.org/v2/competitions";
            Team = $"http://api.football-data.org/v2/teams/{id}";
            LeagueStan = $"https://api.football-data.org/v2/competitions/{id}/standings?standing";
        }
        public Links()
        {
            url = "https://www.football-data.org/";
            WorldCup = $"http://api.football-data.org/v2/competitions/2000/matches?matchday";
            Champions = $"http://api.football-data.org/v2/competitions/2001/matches?matchday";
            Bundesliga = $"http://api.football-data.org/v2/competitions/2002/matches?matchday";
            Leagues = $"http://api.football-data.org/v2/competitions";
       
        }
       

       
    }
    
}
