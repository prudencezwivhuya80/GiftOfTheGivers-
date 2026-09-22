using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using GiftOfTheGivers.Models;

namespace GiftOfTheGivers.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
            
            public DbSet<Donation> Donations { get; set;  }
            public DbSet<Volunteer> Volunteers { get; set; } 
          
            public DbSet<ProjectUpdate> ProjectUpdates { get; set; }
        }
    }

