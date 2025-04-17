using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using WCBS.API.Tests.Common;
using Newtonsoft.Json;

namespace WCBS.API.Tests.Login
{
    public static class PostTokenRequestData
    {
        public static string Email { get; set; }
        public static string SharedSecret { get; set; }
    }
}
