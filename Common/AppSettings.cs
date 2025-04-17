using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCBS.API.Tests.Common
{
    public class AppConfig
    {
        public const string BaseSettings = "BaseSettings";
        public const string LoginSettings = "LoginSettings";
        public string BaseURL { get; set; } = string.Empty;
      
    }

    

    public class LoginSettingsSection
    {
        public string Email { get; set; } = string.Empty;
        public string SharedSecret { get; set; } = string.Empty;
   
    }
    public class RaceResponse
    {
        [JsonProperty("raceId")]
        public string RaceId { get; set; } = string.Empty;

        [JsonProperty("description")]
        public string Description { get; set; } = string.Empty;
    }

    public class RacesApiResponse
    {
        public List<RaceResponse> Races { get; set; }

    }

}
