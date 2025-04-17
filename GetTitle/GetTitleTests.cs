using FluentAssertions;
using Microsoft.Playwright;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WCBS.API.Tests.Common;

namespace WCBS.API.Tests.GetTitle
{
    public class TitleTest : BaseTest
    {
        private IAPIRequestContext _request;



        [Test]
        public async Task GetTitles_WithValidToken_ReturnsTitleList()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "api/v1/Title");
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

