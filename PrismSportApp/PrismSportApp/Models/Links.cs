using System;
using System.Collections.Generic;
using System.Text;

namespace PrismSportApp.Models
{
    public class Links
    {
        public const string Url = "https://www.football-data.org/";
        public const string WorldCup = "http://api.football-data.org/v2/competitions/2000/matches?matchday";
        public const string Champions = "http://api.football-data.org/v2/competitions/2001/matches?matchday";
        public const string Bundesliga = "http://api.football-data.org/v2/competitions/2002/matches?matchday";
        public const string Leagues = "http://api.football-data.org/v2/competitions";
        public const string Team = "http://api.football-data.org/v2/teams/{id}";
        public const string LeagueStan = "https://api.football-data.org/v2/competitions/{id}/standings?standing";
    }
}
