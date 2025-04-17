using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCBS.API.Tests.Models
{
    public class DonorDocumentResponse
    {
        [JsonProperty("donorDocuments")]
        public List<DonorDocument> DonorDocuments { get; set; }
    }

    public class DonorDocument
    {
        public string DocumentId { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public string DonorId { get; set; } = string.Empty;
        public int DonorDocumentType { get; set; }
        public string Filename { get; set; } = string.Empty;
        public string FileExtension { get; set; }
        public bool IsRemoved { get; set; }
        public bool IsSynced { get; set; }
    }
}

