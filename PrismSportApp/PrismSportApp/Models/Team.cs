using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrismSportApp.Models
{
    //public class Area
    //{

    //    [JsonProperty("id")]
    //    public int Id { get; set; }

    //    [JsonProperty("name")]
    //    public string Name { get; set; }
    //}

    public class Squad
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("position")]
        public string Position { get; set; }

        [JsonProperty("dateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        [JsonProperty("countryOfBirth")]
        public string CountryOfBirth { get; set; }

        [JsonProperty("nationality")]
        public string Nationality { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }
    }

    public class Team
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("area")]
        public Area Area { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("shortName")]
        public string ShortName { get; set; }

        [JsonProperty("tla")]
        public string Tla { get; set; }

        [JsonProperty("crestUrl")]
        public string CrestUrl { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("founded")]
        public int Founded { get; set; }

        [JsonProperty("clubColors")]
        public string ClubColors { get; set; }

        [JsonProperty("venue")]
        public string Venue { get; set; }

        [JsonProperty("squad")]
        public IList<Squad> Squad { get; set; }

        [JsonProperty("lastUpdated")]
        public DateTime LastUpdated { get; set; }
    }
}
