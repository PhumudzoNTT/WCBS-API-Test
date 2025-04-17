using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;


namespace WCBS.API.Tests.Donor;


public static class DonorAssertions
{
    public static void ShouldBeValid(this DonorResponse donor)
    {
        donor.Should().NotBeNull();
        donor.DonorId.Should().NotBeNullOrEmpty();
        donor.Email.Should().Contain("@");
        donor.FullName.Should().NotBeNullOrWhiteSpace();
        donor.Address.PostalCode.Should().NotBeNullOrWhiteSpace();
    }
}