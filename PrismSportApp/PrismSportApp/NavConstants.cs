using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrismSportApp
{
    public class NavConstants
    {

        public string TabMenu { get; set; }
        public string MasterMenu { get; set; }
        public string DetailLeague { get; set; }
        public string TeamInfo { get; set; }
        public string FavoriteLeague { get; set; }

        public NavConstants()
        {
            TabMenu = $"/MenuStandings?{KnownNavigationParameters.SelectedTab}=DetailLeagueView";
            MasterMenu = "/MenuPages/NavigationPage/ListLeaguesPage";
            DetailLeague = "DetailLeagueView";
            TeamInfo = "TeamInfoPage";
            FavoriteLeague = "LeagueFavoritePage";
        }
      

    }
}
