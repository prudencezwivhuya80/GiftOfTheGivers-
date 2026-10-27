using GiftOfTheGivers.Helpers;
using Xunit;

namespace GiftOfTheGivers.Tests
{
    public class DonationHelperTests
    {
        [Fact]
        public void FormatCertificateNumber_PadsTheNumber()
        {
            string result = DonationHelper.FormatCertificateNumber(12);

            Assert.Equal($"GOG-{DateTime.Now.Year}-000012", result);
        }

        [Fact]
        public void CalculateDonationTotal_AddsAllAmounts()
        {
            decimal[] amounts = { 100m, 250.50m, 49.50m };

            decimal total = DonationHelper.CalculateDonationTotal(amounts);

            Assert.Equal(400m, total);
        }

        [Fact]
        public void CalculateDonationTotal_EmptyArray_ReturnsZero()
        {
            decimal[] amounts = { };

            decimal total = DonationHelper.CalculateDonationTotal(amounts);

            Assert.Equal(0m, total);
        }

        [Fact]
        public void CalculateDonationTotal_SingleAmount_ReturnsThatAmount()
        {
            decimal[] amounts = { 75m };

            decimal total = DonationHelper.CalculateDonationTotal(amounts);

            Assert.Equal(75m, total);
        }

        [Fact]
        public void FormatCertificateNumber_AlwaysStartsWithGOG()
        {
            string result = DonationHelper.FormatCertificateNumber(5);

            Assert.StartsWith("GOG-", result);
        }
    }
}