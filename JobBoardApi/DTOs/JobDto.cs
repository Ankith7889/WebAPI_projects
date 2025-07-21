namespace JobBoardApi.DTOs
{
    public class JobDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Company { get; set; } = null!;
        public bool IsApproved { get; set; }
    }
}
