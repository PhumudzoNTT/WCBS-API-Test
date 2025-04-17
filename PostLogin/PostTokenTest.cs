

using System.Threading.Tasks;
using NUnit.Framework;
using WCBS.API.Tests.Common;
using WCBS.API.Tests.Models;
using WCBS.API.Tests.Helpers;
using FluentAssertions;
using Newtonsoft.Json;

namespace WCBS.API.Tests.Tests
{
    public class TokenApiTests : BaseTest
    {
        [Test]
        public async Task GenerateToken_WithValidEmailAndSharedSecret_ReturnsTokenAndExpiration()
        {
            var payload = TokenHelper.CreateRequestPayload(
                _appSettings.LoginSettingsSection.Email,
                _appSettings.LoginSettingsSection.SharedSecret
            );

            var response = await _httpClient.PostAsync("/api/V1/Account/Token/OnBehalfOf/Email", payload);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<PostTokenResponseData>(content);

            result.Should().NotBeNull();
            result.Token.Should().NotBeNullOrEmpty();
            result.Expiration.Should().NotBeNullOrEmpty();
        }
    }
}
