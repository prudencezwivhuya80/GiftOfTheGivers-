using Microsoft.AspNetCore.Authorization;
using GiftOfTheGivers.Data;
using Microsoft.AspNetCore.Mvc;
using GiftOfTheGivers.Models;
using Microsoft.EntityFrameworkCore;
using GiftOfTheGivers.Views.Home;
using GiftOfTheGivers.Data.Migrations;

namespace GiftOfTheGivers.Controllers
{
    [Authorize(Roles = "Employee")]
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            var model = new EmployeeDashboardViewModel
            {

                Volunteers = _context.Volunteers.OrderByDescending(v => v.SubmittedDate).ToList(),
                ProjectUpdates = _context.ProjectUpdates.OrderByDescending(p => p.PostedDate).ToList()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult PostUpdate(ProjectUpdate update)
        {
            update.PostedBy = User.Identity?.Name ?? "Employee";
            update.PostedDate = DateTime.Now;

            _context.ProjectUpdates.Add(update);
            _context.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}


