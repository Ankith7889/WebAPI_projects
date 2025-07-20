﻿namespace JobBoardApi.Models
{ 
    public class JobApplication
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public Job Job { get; set; } = null!;

        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public DateTime AppliedAt { get; set; } = DateTime.UtcNow;
    }
}
