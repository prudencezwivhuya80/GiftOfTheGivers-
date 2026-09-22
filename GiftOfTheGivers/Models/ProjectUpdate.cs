using System.ComponentModel.DataAnnotations;

namespace GiftOfTheGivers.Models
{
    public class ProjectUpdate
    {

        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Content { get; set; } = string.Empty;
        public string PostedBy { get; set; } = string.Empty;

        public DateTime PostedDate { get; set; } = DateTime.Now;


    }
}
