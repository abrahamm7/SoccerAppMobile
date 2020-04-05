using FFImageLoading.Svg.Forms;
using Prism.Commands;
using Prism.Navigation;
using PrismSportApp.Models;
using PrismSportApp.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Xml.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using Microcharts.Forms;
using Microcharts;

namespace PrismSportApp.ViewModels
{
    public class TeamInfoViewModel: INotifyPropertyChanged, INavigatedAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Table Table { get; set; } = new Table();
        public Chart RadielGaugeChartSample => new RadialGaugeChart()
        {
            Entries = new[]
            {
                new Microcharts.Entry(Table.Won)
                {
                    Color = SkiaSharp.SKColor.Parse("#4CAF50"),
                    Label = "Won",
                    ValueLabel = Table.Won.ToString(),
                },
                new Microcharts.Entry(Table.Draw)
                {
                    Color = SkiaSharp.SKColor.Parse("#9E9E9E"),
                    Label = "Draw",
                    ValueLabel = Table.Draw.ToString(),
                },
                new Microcharts.Entry(Table.Lost)
                {
                    Color = SkiaSharp.SKColor.Parse("#F44336"),                    
                    Label = "Lost",
                    ValueLabel = Table.Lost.ToString(),
                },
                new Microcharts.Entry(Table.PlayedGames)
                {
                    Color = SkiaSharp.SKColor.Parse("#FFC107"),
                    Label = "Played Games",
                    ValueLabel = Table.PlayedGames.ToString(),
                },
            },
            LineSize = 30,            
            LabelTextSize = 45,
            MaxValue = Table.PlayedGames
        };

        public Chart RadielGaugeGoals => new RadialGaugeChart()
        {
            Entries = new[]
            {
                new Microcharts.Entry(Table.GoalsFor)
                {
                    Color = SkiaSharp.SKColor.Parse("#303F9F"),
                    Label = "Goals",
                    ValueLabel = Table.GoalsFor.ToString(),
                },
                new Microcharts.Entry(Table.GoalsAgainst)
                {
                    Color = SkiaSharp.SKColor.Parse("#4CAF50"),
                    Label = "Against",
                    ValueLabel = Table.GoalsAgainst.ToString(),
                },
                new Microcharts.Entry(Table.GoalDifference)
                {
                    Color = SkiaSharp.SKColor.Parse("#9C27B0"),
                    Label = "Goals Difference",
                    ValueLabel = Table.GoalDifference.ToString(),
                },               
            },
            LineSize = 30,
            LabelTextSize = 45,
            MaxValue = Table.GoalsFor
        };

        public ICommand Save { get; set; }
        ISqliteInterface Sqlite;
        public void OnNavigatedFrom(INavigationParameters parameters)
        {
           
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            Table = parameters.GetValue<Table>("Team");           
        }
        public TeamInfoViewModel(ISqliteInterface sqliteInterface)
        {
            
        }
        
    }
}
