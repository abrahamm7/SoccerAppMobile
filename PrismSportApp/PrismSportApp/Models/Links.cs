using System;
using System.Collections.Generic;
using System.Text;

namespace PrismSportApp.Models
{
    public class Links
    {
        public string url { get; set; }
        public string matches { get; set; }     
        public string Leagues { get; set; }
        public string Team { get; set; }
        public string LeagueStan { get; set; }
        public Links(int id)
        {
            url = "https://www.football-data.org/";
            matches = $"http://api.football-data.org/v2/competitions/{id}/matches";                     
            Team = $"http://api.football-data.org/v2/teams/{id}";
            LeagueStan = $"https://api.football-data.org/v2/competitions/{id}/standings?standing";
        }
        public Links()
        {          
            Leagues = $"http://api.football-data.org/v2/competitions";
        }
       

       
    }
    
}
