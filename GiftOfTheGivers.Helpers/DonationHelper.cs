using System;

namespace GiftOfTheGivers.Helpers
{
    public static class DonationHelper
    {
        public static string FormatCertificateNumber(int donationId)
        {
            return "GOG-" + DateTime.Now.Year + "-" + donationId.ToString("D6");
        }

        public static decimal CalculateDonationTotal(decimal[] amounts)
        {
            decimal total = 0;

            foreach (decimal amount in amounts)
            {
                total += amount;
            }

            return total;
        }
    }
}