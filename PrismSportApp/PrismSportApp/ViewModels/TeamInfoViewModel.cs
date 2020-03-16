using FFImageLoading.Svg.Forms;
using Prism.Navigation;
using PrismSportApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PrismSportApp.ViewModels
{
    public class TeamInfoViewModel: INotifyPropertyChanged, INavigatedAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Teamm Teamm { get; set; } = new Teamm();
        public string TeamName { get; set; }
        public string Logo { get; set; }
        public string Won { get; set; }
        public string Draw { get; set; }
        public string Lost { get; set; }
        public SvgCachedImage SvgCachedImage { get; set; } = new SvgCachedImage();
        public void OnNavigatedFrom(INavigationParameters parameters)
        {
           
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            this.TeamName = parameters.GetValue<string>("TeamName");
            this.Logo = parameters.GetValue<string>("Logo");
            this.Won = parameters.GetValue<string>("Win");
            this.Lost = parameters.GetValue<string>("Losts");
            this.Draw = parameters.GetValue<string>("Draws");
        }
        public TeamInfoViewModel()
        {
            
        }
    }
}
