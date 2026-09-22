using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GiftOfTheGivers.Models
{
    public class Donation
    {

        public int Id { get; set; }

        [Required]

        public string DonorName { get; set; } = "Anonymous";

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set;  }

        [Required]
        public string Currency { get; set; } = "ZAR";
        public bool IsRecurring { get; set; }
        public DateTime DonationDate { get; set; } = DateTime.Now;
       
    }
}
