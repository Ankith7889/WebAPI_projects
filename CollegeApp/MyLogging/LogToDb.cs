namespace CollegeApp.MyLogging
{
    public class LogToDb : IMyLogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"Log to database: {message}");
        }
    }
}
