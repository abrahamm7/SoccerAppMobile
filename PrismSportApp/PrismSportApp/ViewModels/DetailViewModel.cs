using Prism.Navigation;
using PrismSportApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PrismSportApp.ViewModels
{
    public class DetailViewModel: INotifyPropertyChanged ,INavigatedAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public League League;
        public string NameLeague { get; set; }
        INavigationService navigation;
        public DetailViewModel(INavigationService navigationService)
        {
            navigation = navigationService;
            
        }       

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
           
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            this.NameLeague = parameters.GetValue<string>("Name");
            
        }
    }
}
