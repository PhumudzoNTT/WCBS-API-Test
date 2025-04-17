using Microsoft.Playwright;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCBS.API.Tests.Common;

namespace WCBS.API.Tests.Race
{
    public static class RaceAssertions
    {
        public static void VerifySuccessfulResponse(IAPIResponse response)
        {
            Assert.AreEqual(200, (int)response.Status);

            var responseBody = response.TextAsync().Result;
            var racesResponse = JsonConvert.DeserializeObject<RacesApiResponse>(responseBody);

            Assert.IsNotNull(racesResponse?.Races, "Races collection should not be null");
            Assert.IsTrue(racesResponse.Races.Count > 0, "Should return at least one race");
        }

        public static void VerifyRaceData(List<RaceResponse> races)
        {
            var expectedRaces = new List<RaceResponse>
        {
            new RaceResponse { RaceId = "2", Description = "WHITE FEMALE" },
            new RaceResponse { RaceId = "4", Description = "COLOURED FEMALE" },
            new RaceResponse { RaceId = "6", Description = "ASIAN FEMALE" },
            new RaceResponse { RaceId = "8", Description = "BLACK FEMALE" },
            new RaceResponse { RaceId = "1", Description = "WHITE MALE" },
            new RaceResponse { RaceId = "3", Description = "COLOURED MALE" },
            new RaceResponse { RaceId = "5", Description = "ASIAN MALE" },
            new RaceResponse { RaceId = "7", Description = "BLACK MALE" }
        };

            foreach (var expectedRace in expectedRaces)
            {
                var actualRace = races.FirstOrDefault(r => r.RaceId == expectedRace.RaceId);
                Assert.IsNotNull(actualRace, $"Race with ID {expectedRace.RaceId} not found");
                Assert.AreEqual(expectedRace.Description, actualRace.Description,
                    $"Description mismatch for race ID {expectedRace.RaceId}");
            }
        }
    }
}
