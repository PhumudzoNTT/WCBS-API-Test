using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WCBS.API.Tests.Assertions;
using WCBS.API.Tests.Common;
using WCBS.API.Tests.Models;

namespace WCBS.API.Tests.Tests
{
    public class DonorDocumentApiTests : BaseTest
    {
        [Test]
        public async Task GetDonorDocuments_ShouldReturnValidDocuments()
        {
            var token = await GetAuthTokenAsync();

            var request = new HttpRequestMessage(HttpMethod.Get, "/api/v1/DonorDocument")
            {
                Headers = {
                    { "Authorization", $"Bearer {token}" }
                }
            };

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var donorDocs = JsonConvert.DeserializeObject<DonorDocumentResponse>(content);

            donorDocs.ShouldHaveValidData();
        }
    }
}