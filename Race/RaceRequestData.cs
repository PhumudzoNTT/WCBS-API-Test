using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCBS.API.Tests.Race
{
    public static class RaceRequestData
    {
        public static string BaseUrl => "/api/v1/Race";

        public static APIRequestContextOptions GetRequestOptions()
        {
            return new APIRequestContextOptions
            {
                Headers = new Dictionary<string, string>
            {
                { "Content-Type", "application/json" },
                { "Accept", "application/json" }

            }
            };
        }
    }
}
