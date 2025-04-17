using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using WCBS.API.Tests.Assertions;
using WCBS.API.Tests.Common;
using WCBS.API.Tests.Models;

namespace WCBS.API.Tests.Tests
{
    public class GetBloodLevelTests : BaseTest
    {
        [Test]
        public async Task GetBloodLevel_ShouldReturnValidData()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/v1/Blood/WP/BloodLevels");
            request.Headers.Add("Authorization", $"Bearer {authToken}");

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var bloodLevelData = JsonConvert.DeserializeObject<List<BloodLevelResponse>>(responseContent);

            bloodLevelData.ShouldHaveValidData();
        }
    }
}
