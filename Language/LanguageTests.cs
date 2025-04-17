using System.Threading.Tasks;
using NUnit.Framework;
using WCBS.API.Tests.Common;
using FluentAssertions;
using System.Net.Http;

namespace WCBS.API.Tests.Tests
{
    public class LanguageApiTests : BaseTest
    {
        [Test]
        public async Task GetLanguages_WithValidToken_ReturnsLanguageList()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/v1/Language");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authToken);

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            content.Should().NotBeNullOrWhiteSpace("Expected language list in response");

            TestContext.WriteLine("Response Body:");
            TestContext.WriteLine(content);
        }
    }
}
