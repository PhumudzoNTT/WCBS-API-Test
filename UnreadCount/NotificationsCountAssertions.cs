using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WCBS.API.Tests.Common;

namespace WCBS.API.Tests.UnreadCount
{


    public static class NotificationCountAssertions
    {
        public static void ShouldBeValidCount(this int count)
        {
            count.Should().BeGreaterOrEqualTo(0, "Notification count should not be negative");
        }
    }
}
