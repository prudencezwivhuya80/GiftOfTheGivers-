using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;

namespace GiftOfTheGivers.Functions
{
    public class GenerateTaxCertificate
    {
        [Function("GenerateTaxCertificate")]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req)
        {
            string donorName = req.Query["donorName"].ToString();
            string amountText = req.Query["amount"].ToString();
            string certificateNumber = req.Query["certificateNumber"].ToString();

            if (donorName == "" || amountText == "" || certificateNumber == "")
            {
                return new BadRequestObjectResult(
                    "Please provide the donor name, amount and certificate number.");
            }

            decimal amount;

            if (!decimal.TryParse(amountText, out amount))
            {
                return new BadRequestObjectResult(
                    "Please enter a valid donation amount.");
            }

            if (amount <= 0)
            {
                return new BadRequestObjectResult(
                    "The donation amount must be greater than zero.");
            }

            string certificate =
                "GIFT OF THE GIVERS FOUNDATION\n" +
                "Section 18A Tax Certificate\n" +
                "--------------------------------\n" +
                "Certificate Number: " + certificateNumber + "\n" +
                "Donor: " + donorName + "\n" +
                "Amount Donated: R" + amount.ToString("0.00") + "\n" +
                "Date Issued: " + DateTime.Now.ToString("dd MMMM yyyy") + "\n" +
                "--------------------------------\n" +
                "This is a sample certificate for a college project.";

            return new OkObjectResult(certificate);
        }
    }
}