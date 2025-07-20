using Microsoft.AspNetCore.Builder;

namespace JobBoardApi.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Company { get; set; } = null!;
        public DateTime PostedAt { get; set; } = DateTime.UtcNow;
        public bool IsApproved { get; set; } = false;
        public ICollection<JobApplication> Applications { get; set; } = new List<JobApplication>();
    }

}
