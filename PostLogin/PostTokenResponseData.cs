using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WCBS.API.Tests.Models
{
    public class PostTokenResponseData
    {
        public string Token { get; set; }
        public string Expiration { get; set; }
    }
}

