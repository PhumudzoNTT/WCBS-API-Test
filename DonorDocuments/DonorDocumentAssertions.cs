using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCBS.API.Tests.Models;

namespace WCBS.API.Tests.Assertions
{
    public static class DonorDocumentAssertions
    {
        public static void ShouldHaveValidData(this DonorDocumentResponse response)
        {
            response.Should().NotBeNull();
            response.DonorDocuments.Should().NotBeNullOrEmpty();

            foreach (var doc in response.DonorDocuments)
            {
                doc.DocumentId.Should().NotBeNullOrWhiteSpace();
                doc.DonorId.Should().NotBeNullOrWhiteSpace();
                doc.Filename.Should().NotBeNullOrWhiteSpace();
                doc.FileExtension.Should().NotBeNullOrWhiteSpace();
                doc.CreatedDate.Should().BeBefore(DateTime.UtcNow.AddMinutes(1));
            }
        }
    }
}
