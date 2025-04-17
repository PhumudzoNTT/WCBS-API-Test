using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCBS.API.Tests.Notifications
{
    public class NotificationsResponse
    {
        [JsonProperty("notifications")]
        public List<Notification> Notifications { get; set; }
    }

    public class Notification
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }

        [JsonProperty("readDate")]
        public DateTime? ReadDate { get; set; }
    }
}
