using Newtonsoft.Json;

namespace StravaActivities
{
    public class Athlete
    {
        [JsonProperty("id")]
        public int? Id
        {
            get; set;
        }

        [JsonProperty("resource_state")]
        public int? ResourceState
        {
            get; set;
        }

        [JsonProperty("profile_medium")]
        public string ProfileMedium
        {
            get; set;
        }

        [JsonProperty("profile")]
        public string Profile
        {
            get; set;
        }

        [JsonProperty("firstname")]
        public string FirstName
        {
            get; set;
        }

        [JsonProperty("lastname")]
        public string LastName
        {
            get; set;
        }
    }
}

