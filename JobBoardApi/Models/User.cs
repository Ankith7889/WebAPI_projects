﻿using Microsoft.AspNetCore.Builder;

namespace JobBoardApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string Role { get; set; } = "User";
        public ICollection<JobApplication> Applications { get; set; } = new List<JobApplication>();
    }
}
