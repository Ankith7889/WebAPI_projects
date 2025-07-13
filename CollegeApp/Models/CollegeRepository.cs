namespace CollegeApp.Models
{
    public static class CollegeRepository
    {
        public static List<Student> Students {  get; set; } = new List<Student> { new Student
            {
                Id = 1,
                Name = "Ankith",
                Email = "Ankith@gmail.com",
                Phone = "8976573601"
            }
            };
    }
}
