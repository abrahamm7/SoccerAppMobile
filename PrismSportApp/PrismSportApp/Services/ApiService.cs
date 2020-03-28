using Newtonsoft.Json;
using PrismSportApp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace PrismSportApp
{
    public class ApiService: IApiServices
    {
        Links Links;              
        
        public async Task<Fixtures> GetFixtures(int param) 
        {
            Links = new Links(param);
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("x-auth-token", "78425d5d244f4ad4a4cb1d864b9ee167");
            var text = await httpClient.GetStringAsync(Links.matches);
            return JsonConvert.DeserializeObject<Fixtures>(text);

        }
        public async Task<Competitions> GetLeagues()
        {
            Links = new Links();
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("x-auth-token", "78425d5d244f4ad4a4cb1d864b9ee167");
            var text = await httpClient.GetStringAsync(Links.Leagues);
            return JsonConvert.DeserializeObject<Competitions>(text);

        }
        public async Task<Standings> GetStandings(int param)
        {
            Links = new Links(param);
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("x-auth-token", "78425d5d244f4ad4a4cb1d864b9ee167");          
            var text = await httpClient.GetStringAsync(Links.LeagueStan);
            return JsonConvert.DeserializeObject<Standings>(text);

        }
    }
}


