using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrismSportApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuStandings : TabbedPage
    {
        public MenuStandings()
        {
            InitializeComponent();
            BindingContext = new DetailLeagueView();
            BindingContext = new MatchesPage();
        }
    }
}