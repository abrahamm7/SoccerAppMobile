using Newtonsoft.Json;
using Prism.Services;
using Prism.Services.Dialogs;
using PrismSportApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace PrismSportApp
{
    public class ApiService: IApiServices
    {
        Links Links;
        IPageDialogService PageDialog;
        public ApiService(IPageDialogService pageDialogService)
        {
            PageDialog = pageDialogService;
        }
        public async Task<Fixtures> GetFixtures(int param) 
        {
            try
            {
                if (Connectivity.NetworkAccess == NetworkAccess.Internet)
                {
                    Links = new Links(param);
                    HttpClient httpClient = new HttpClient();
                    httpClient.DefaultRequestHeaders.Add("x-auth-token", "78425d5d244f4ad4a4cb1d864b9ee167");
                    var text = await httpClient.GetStringAsync(Links.matches);
                    return JsonConvert.DeserializeObject<Fixtures>(text); 
                }
                else
                {              
                    await PageDialog.DisplayAlertAsync("Advice", "Not connection to internet", "Ok");
                    return null;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }

        }        
        public async Task<Competitions> GetLeagues()
        {
            try
            {
                if (Connectivity.NetworkAccess == NetworkAccess.Internet)
                {
                    Links = new Links();
                    HttpClient httpClient = new HttpClient();
                    httpClient.DefaultRequestHeaders.Add("x-auth-token", "78425d5d244f4ad4a4cb1d864b9ee167");
                    var text = await httpClient.GetStringAsync(Links.Leagues);
                    return JsonConvert.DeserializeObject<Competitions>(text); 
                }
                else
                {
                    await PageDialog.DisplayAlertAsync("Advice", "Not connection to internet", "Ok");
                    return null;                   
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<LeagueChampions> GetLeagues(int param)
        {
            try
            {
                if (Connectivity.NetworkAccess == NetworkAccess.Internet)
                {
                    Links = new Links(param);
                    HttpClient httpClient = new HttpClient();
                    httpClient.DefaultRequestHeaders.Add("x-auth-token", "78425d5d244f4ad4a4cb1d864b9ee167");
                    var text = await httpClient.GetStringAsync(Links.LeaguesChampions);
                    return JsonConvert.DeserializeObject<LeagueChampions>(text); 
                }
                else
                {
                    await PageDialog.DisplayAlertAsync("Advice", "Not connection to internet", "Ok");
                    return null;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }
        public async Task<Standings> GetStandings(int param)
        {
            try
            {
                
                if (Connectivity.NetworkAccess == NetworkAccess.Internet)
                {
                    Links = new Links(param);
                    HttpClient httpClient = new HttpClient();
                    httpClient.DefaultRequestHeaders.Add("x-auth-token", "78425d5d244f4ad4a4cb1d864b9ee167");
                    var text = await httpClient.GetStringAsync(Links.LeagueStan);
                    return JsonConvert.DeserializeObject<Standings>(text); 
                }
                else
                {
                    await PageDialog.DisplayAlertAsync("Advice", "Not connection to internet", "Ok");
                    return null;
                }
            }   
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }

        }
    }
}


