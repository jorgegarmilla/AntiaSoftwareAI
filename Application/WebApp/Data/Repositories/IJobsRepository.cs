using WebApp.Client.ModelView;

namespace WebApp.Data.Repositories
{
    public interface IJobsRepository
    {
        Task<List<JobModelView>> GetAllJobsAsync();

        Task<JobModelView> GetJobByIdAsync(int jobId);

        Task AddJobAsync(JobModelView job);

        Task UpdateJobAsync(JobModelView job);

        Task DeleteJobAsync(int jobId);

    }
}
