namespace GiftOfTheGivers.Models
{
    public class EmployeeDashboardViewModel
    {
        public List<Volunteer> Volunteers { get; set; } = new List<Volunteer>();
        public List<ProjectUpdate> ProjectUpdates { get; set; } = new List<ProjectUpdate>();
    }
}
