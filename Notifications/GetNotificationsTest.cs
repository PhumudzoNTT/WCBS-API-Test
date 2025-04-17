using FluentAssertions;
using Microsoft.Playwright;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WCBS.API.Tests.Common;

namespace WCBS.API.Tests.Notifications
{
    public class GetNotificationsTest : BaseTest
    {
        [Test]
        public async Task GetNotifications_ShouldReturnValidData()
        {
            var token = await GetAuthTokenAsync();

            var response = await Request.GetAsync("/api/v1/Notification", new APIRequestContextOptions
            {
                Headers = new Dictionary<string, string>
        {
            { "Authorization", $"Bearer {token}" }
        }
            });

            response.Status.Should().Be(200);

            var content = await response.TextAsync();

            var body = JsonConvert.DeserializeObject<NotificationsResponse>(content);
            body.Should().NotBeNull();
            body.ShouldHaveValidData();
        }


    }
}
