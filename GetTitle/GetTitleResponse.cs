using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCBS.API.Tests.GetTitle
{
    public class TitleResponse
    {
        public List<Title> Titles { get; set; }
    }

    public class Title
    {
        public string TitleId { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}

