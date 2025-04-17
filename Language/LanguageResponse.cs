using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCBS.API.Tests.Language
{
    public class LanguageResponse
    {
        public List<Language> Languages { get; set; } 
    }

    public class Language
    {
        public string Id { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Iso1 { get; set; } = string.Empty;
        public string Iso2 { get; set; } = string.Empty;
        public bool Default { get; set; } 
        public bool IsCommunicationEnabled { get; set; } 
    }
}
