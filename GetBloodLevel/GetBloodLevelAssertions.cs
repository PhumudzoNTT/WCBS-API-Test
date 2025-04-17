using FluentAssertions;
using System.Collections.Generic;
using WCBS.API.Tests.Models;

namespace WCBS.API.Tests.Assertions
{
    public static class BloodLevelAssertions
    {
        public static void ShouldHaveValidData(this List<BloodLevelResponse> response)
        {
            response.Should().NotBeNullOrEmpty("response should contain blood level data");

            foreach (var item in response)
            {
                item.Type.Should().NotBeNullOrWhiteSpace("blood type should be defined");
                item.Stock.Should().BeGreaterThan(0, "stock should be a positive number");
                item.Required.Should().BeGreaterThan(0, "required units should be a positive number");
                item.Ratio.Should().BeGreaterOrEqualTo(0, "ratio should be zero or more");
                item.State.Should().NotBeNullOrWhiteSpace("state message should be provided");
                item.Image.Should().NotBeNullOrWhiteSpace("image path should be provided");
                item.ImageOverlay.Should().NotBeNullOrWhiteSpace("overlay image path should be provided");
            }
        }
    }
}