using GiftOfTheGivers.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using GiftOfTheGivers.Data;
using Microsoft.Identity.Client;
using GiftOfTheGivers.Services;
using GiftOfTheGivers.Helpers;

namespace GiftOfTheGivers.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        private readonly CertificateService _certificateService;

        public HomeController(ILogger<HomeController> logger,ApplicationDbContext context,CertificateService certificateService )
        {
            _logger = logger;
            _context = context;
            _certificateService = certificateService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
        public IActionResult Donate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Donate(Donation donation)
        {
            _context.Donations.Add(donation);
            _context.SaveChanges();

            string certificateNumber = DonationHelper.FormatCertificateNumber(donation.Id);

            string certificate = await _certificateService.GetCertificateAsync(donation.DonorName, donation.Amount, certificateNumber);

            ViewBag.Certificate = certificate;

            return View("DonationSuccess", donation);
        }
        public IActionResult Volunteer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Volunteer(Volunteer volunteer)
        {
            _context.Volunteers.Add(volunteer);
            _context.SaveChanges();

            return View("VolunteerSuccess", volunteer);
        }
        public IActionResult Contact()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
