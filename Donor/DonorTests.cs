using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using WCBS.API.Tests.Common;
using WCBS.API.Tests.Models;
using WCBS.API.Tests.Assertions;
using WCBS.API.Tests.Donor;

namespace WCBS.API.Tests.Tests
{
    public class DonorApiTests : BaseTest
    {
        [Test]
        public async Task GetDonor_ReturnsValidDonorData()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/v1/Donor")
            {
                Headers =
                {
                    { "Authorization", $"Bearer {authToken}" },
                    { "Accept", "application/json" }
                }
            };

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var donor = JsonConvert.DeserializeObject<DonorResponse>(content);

            donor.ShouldBeValid();
        }
    }
}
