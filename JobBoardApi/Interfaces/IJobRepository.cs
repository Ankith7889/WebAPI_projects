using JobBoardApi.Models;

public interface IJobRepository
{
    Task<IEnumerable<Job>> GetAllAsync();
    Task<Job?> GetByIdAsync(int id);
    Task AddAsync(Job job);
    Task DeleteAsync(Job job);
    Task SaveChangesAsync();
}
