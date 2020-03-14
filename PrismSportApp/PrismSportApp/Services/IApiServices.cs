using PrismSportApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Refit;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace PrismSportApp
{
    public interface IApiServices
    {
      

        [Get("/api.football-data.org/v2/competitions/2000/matches?matchday")]
        Task<Fixtures> GetFixturesWorldCup();
        
        [Get("/api.football-data.org/v2/competitions/2001/matches?matchday")]
        Task<Fixtures> GetFixturesUefaChampions();
       
        [Get("/api.football-data.org/v2/competitions/2002/matches?matchday")]
        Task<Fixtures> GetFixturesBundesliga();        

        [Get("/api.football-data.org/v2/competitions")]
        Task<Competitions> GetLeagues();
        
        Task<LeagueStandings> GetStandings(int id);
        
    }
}
