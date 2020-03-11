using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PrismSportApp.Models
{
    public class CompetitionsList
    {        

    }
    public class Filt
    {
    }

    public class Areaas
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public string EnsignUrl { get; set; }
    }

    public class Winner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Tla { get; set; }
        public string CrestUrl { get; set; }
    }

    public class CurrentSeason
    {
        public int Id { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int? CurrentMatchday { get; set; }
        public Winner Winner { get; set; }
    }

    public class League
    {
        public int Id { get; set; }
        public Areaas Area { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string EmblemUrl { get; set; }
        public string Plan { get; set; }
        public CurrentSeason CurrentSeason { get; set; }
        public int NumberOfAvailableSeasons { get; set; }
        public DateTime LastUpdated { get; set; }
    }

    public class Competitions
    {
        public int Count { get; set; }
        public Filters Filters { get; set; }
        public ObservableCollection<League> competitions { get; set; }
    }
}
