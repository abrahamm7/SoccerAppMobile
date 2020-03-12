using PrismSportApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace PrismSportApp.ViewModels
{
    public class TeamPageViewModel
    {
        IApiServices _apiService = new ApiService();
        public Team Team { get; set; }

        public TeamPageViewModel()
        {
            GetDataAysnc();
        }

        async Task GetDataAysnc()
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                try
                {
                    Team = await _apiService.GetId(18);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"API EXCEPTION {ex}");
                }

            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "Internet connection fail", "Ok");
                //Show internet connection error message HERE
            }

        }





    }
}





    
   