namespace JobBoardApi.DTOs
{
    public class CreateJobDto
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Company { get; set; } = null!;
    }
}
