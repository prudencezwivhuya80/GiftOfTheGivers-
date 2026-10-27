using GiftOfTheGivers.Controllers;
using GiftOfTheGivers.Data;
using GiftOfTheGivers.Models;
using GiftOfTheGivers.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.Abstractions;
using System.Net;
using Xunit;

namespace GiftOfTheGivers.Tests
{
    // Stands in for the live Azure Function so the test does not depend on the internet.
    public class FakeCertificateHandler : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("GIFT OF THE GIVERS FOUNDATION\nTest certificate")
            };

            return Task.FromResult(response);
        }
    }

    public class DonationFlowTests
    {
        private HomeController BuildController(ApplicationDbContext context)
        {
            var configValues = new Dictionary<string, string>
            {
                { "CertificateFunction:Url", "http://fake-url/api/GenerateTaxCertificate" }
            };

            var config = new ConfigurationBuilder()
                .AddInMemoryCollection(configValues)
                .Build();

            var fakeClient = new HttpClient(new FakeCertificateHandler());
            var certificateService = new CertificateService(fakeClient, config);

            return new HomeController(NullLogger<HomeController>.Instance, context, certificateService);
        }

        [Fact]
        public async Task Donate_SavesDonationAndReturnsSuccessView()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("DonationFlowTestDb1")
                .Options;

            using var context = new ApplicationDbContext(options);
            var controller = BuildController(context);

            var donation = new Donation
            {
                DonorName = "Thandi",
                Amount = 500m,
                Currency = "ZAR"
            };

            var result = await controller.Donate(donation);

            Assert.Single(context.Donations);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task Donate_MissingDonorName_DefaultsToAnonymous()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("DonationFlowTestDb2")
                .Options;

            using var context = new ApplicationDbContext(options);
            var controller = BuildController(context);

            var donation = new Donation
            {
                DonorName = "",
                Amount = 250m,
                Currency = "ZAR"
            };

            await controller.Donate(donation);

            var saved = context.Donations.First();
            Assert.Equal("Anonymous", saved.DonorName);
        }
    }
}