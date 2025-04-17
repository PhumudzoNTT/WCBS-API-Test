using System;
using System.Collections.Generic;

namespace WCBS.API.Tests.Models
{
    public class MedicalScreeningResponse
    {
        public List<MedicalScreening> MedicalScreenings { get; set; }
    }

    public class MedicalScreening
    {
        public DateTime Date { get; set; }
        public string BloodPressure { get; set; } = string.Empty;
    }
}