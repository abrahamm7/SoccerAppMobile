using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PrismSportApp.Services;

namespace PrismSportApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPages : Xamarin.Forms.TabbedPage
    {
        public MenuPages()
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
        }
    }
}