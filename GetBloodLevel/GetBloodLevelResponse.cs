using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCBS.API.Tests.Models
{
    public class BloodLevelResponse
    {
        public int Stock { get; set; } 
        public string Type { get; set; } = string.Empty;
        public int Required { get; set; }
        public int Ratio { get; set; }
        public string State { get; set; } = string.Empty;
        public string Image { get; set; }
        public string ImageOverlay { get; set; } = string.Empty;
    }
}
