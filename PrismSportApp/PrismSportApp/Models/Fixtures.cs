using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PrismSportApp.Models
{
    public class Filters
    {
        public string Matchday { get; set; }
    }

    public class Area
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Competition
    {
        public int Id { get; set; }
        public Area Area { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Plan { get; set; }
        public DateTime LastUpdated { get; set; }
    }

    public class Season
    {
        public int Id { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int CurrentMatchday { get; set; }
    }

    public class Odds
    {
        public string Msg { get; set; }
    }

    public class FullTime
    {
        public int? HomeTeam { get; set; }
        public int? AwayTeam { get; set; }
    }

    public class HalfTime
    {
        public int? HomeTeam { get; set; }
        public int? AwayTeam { get; set; }
    }

    public class ExtraTime
    {
        public object HomeTeam { get; set; }
        public object AwayTeam { get; set; }
    }

    public class Penalties
    {
        public object HomeTeam { get; set; }
        public object AwayTeam { get; set; }
    }

    public class Score
    {
        public string Winner { get; set; }
        public string Duration { get; set; }
        public FullTime FullTime { get; set; }
        public HalfTime HalfTime { get; set; }
        public ExtraTime ExtraTime { get; set; }
        public Penalties Penalties { get; set; }
    }

    public class HomeTeam
    {
        public int? Id { get; set; }
        public string Name { get; set; }
    }

    public class AwayTeam
    {
        public int? Id { get; set; }
        public string Name { get; set; }
    }

    public class Referee
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public object Nationality { get; set; }
    }

    public class Match
    {
        public int Id { get; set; }
        public Season Season { get; set; }
        public DateTime UtcDate { get; set; }
        public string Status { get; set; }
        public int? Matchday { get; set; }
        public string Stage { get; set; }
        public string Group { get; set; }
        public DateTime LastUpdated { get; set; }
        public Odds Odds { get; set; }
        public Score Score { get; set; }
        public HomeTeam HomeTeam { get; set; }
        public AwayTeam AwayTeam { get; set; }
        public IList<Referee> Referees { get; set; }
    }

    public class Fixtures
    {
        public int Count { get; set; }
        public Filters Filters { get; set; }
        public Competition Competition { get; set; }
        public List<Match> Matches { get; set; }
    }
}
