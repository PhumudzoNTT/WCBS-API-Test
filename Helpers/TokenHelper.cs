using Newtonsoft.Json;
using System.Net.Http;
using WCBS.API.Tests.Models;

namespace WCBS.API.Tests.Helpers
{
    public class TokenHelper
    {
        public static StringContent CreateRequestPayload(string email, string sharedSecret)
        {
            var request = new PostTokenRequestData
            {
                email = email,
                sharedSecret = sharedSecret
            };

            var json = JsonConvert.SerializeObject(request);
            return new StringContent(json, System.Text.Encoding.UTF8, "application/json");
        }

        private class PostTokenRequestData
        {
            public string email { get; set; }
            public string sharedSecret { get; set; } = string.Empty;
        }
    }
}