using System.Threading.Tasks;
using NUnit.Framework;
using WCBS.API.Tests.Common;
using FluentAssertions;
using System.Net.Http;

namespace WCBS.API.Tests.Tests
{
    public class RaceApiTests : BaseTest
    {
        [Test]
        public async Task GetRaces_WithValidToken_ReturnsRaceList()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/v1/Race");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authToken);

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            content.Should().NotBeNullOrWhiteSpace("Expected race list in response");

            TestContext.WriteLine("Response Body:");
            TestContext.WriteLine(content);
        }
    }
}