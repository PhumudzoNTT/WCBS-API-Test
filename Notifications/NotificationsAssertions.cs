using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCBS.API.Tests.Notifications
{
    public static class NotificationAssertions
    {
        public static void ShouldHaveValidData(this NotificationsResponse response)
        {
            response.Should().NotBeNull("Response should not be null");
            response.Notifications.Should().NotBeNull("Notifications list should not be null");

            response.Notifications.Should().NotBeEmpty("Notifications should not be empty");

            response.Notifications.Should().OnlyContain(n =>
                n.Id != Guid.Empty &&
                !string.IsNullOrWhiteSpace(n.Title) &&
                n.CreatedDate != default
            );
        }
    }
}
