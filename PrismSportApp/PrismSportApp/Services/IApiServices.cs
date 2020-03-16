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
        [Get("/api.football-data.org/v2/competitions")]
        Task<Competitions> GetLeagues();        
        Task<Standings> GetStandings(int id);
        Task<Fixtures> GetFixtures(int id);
        
    }
}
