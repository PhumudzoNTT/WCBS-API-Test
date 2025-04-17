using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using WCBS.API.Tests.Common;
using WCBS.API.Tests.Models;
using WCBS.API.Tests.Helpers;

namespace WCBS.API.Tests.Tests
{
    public class MedicalScreeningApiTests : BaseTest
    {
        [Test]
        public async Task GetMedicalScreening_ShouldReturnValidData()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/v1/MedicalScreening");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authToken);

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            content.Should().NotBeNullOrWhiteSpace("Expected MedicalSceening response");

            TestContext.WriteLine("Response Body:");
            TestContext.WriteLine(content);
        }
    }
}