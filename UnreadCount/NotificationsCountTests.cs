using FluentAssertions;
using Microsoft.Playwright;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCBS.API.Tests.Common;

namespace WCBS.API.Tests.UnreadCount
{
    public class NotificationsCountTests : BaseTest
    {
        [Test]
        public async Task GetNotificationsCount_ShouldReturnValidData()
        {
            var token = await GetAuthTokenAsync();

            var response = await Request.GetAsync("/api/v1/Notification/unread-count", new APIRequestContextOptions
            {
                Headers = new Dictionary<string, string>
        {
            { "Authorization", $"Bearer {token}" }
        }
            });

            response.Status.Should().Be(200);

            var responseText = await response.TextAsync();
            int count = int.Parse(responseText);

            count.ShouldBeValidCount();
        }
    } 
}


