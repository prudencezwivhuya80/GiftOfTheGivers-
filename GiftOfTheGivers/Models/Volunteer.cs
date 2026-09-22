
using System.ComponentModel.DataAnnotations;

namespace GiftOfTheGivers.Models
{
    public class Volunteer
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; } = string.Empty;

        [Required]

        public string Skills { get; set; } = string.Empty;

        [Required]
        public string Availability { get; set; } = string.Empty;
        public DateTime SubmittedDate { get; set; } = DateTime.Now;

    }
}
