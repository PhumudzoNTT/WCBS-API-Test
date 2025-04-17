using FluentAssertions;
using WCBS.API.Tests.Models;

namespace WCBS.API.Tests.Assertions
{
    public static class MedicalScreeningAssertions
    {
        public static void ShouldBeValid(this MedicalScreeningResponse response)
        {
            response.Should().NotBeNull("Response should not be null.");
            response.MedicalScreenings.Should().NotBeNullOrEmpty("MedicalScreenings list should not be empty.");

            foreach (var screening in response.MedicalScreenings)
            {
                screening.Date.Should().NotBe(default, "Screening date should be valid.");
                screening.BloodPressure.Should().NotBeNullOrWhiteSpace("Blood pressure should be present.");
            }
        }
    }
}
