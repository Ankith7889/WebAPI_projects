namespace JobBoardApi.Helpers
{
    public class ErrorResponse
    {
        public bool Success { get; set; } = false;
        public string Message { get; set; } = "Validation Failed";
        public List<string> Errors { get; set; } = new();
    }
}

