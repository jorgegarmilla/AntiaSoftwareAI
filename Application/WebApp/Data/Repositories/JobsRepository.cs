using WebApp.Client.ModelView;
using WebApp.Client.Pages;

namespace WebApp.Data.Repositories
{
    public class JobsRepository : IJobsRepository
    {
        private List<JobModelView> jobsList = new List<JobModelView>
        {
            new JobModelView { Id= 1, Description = "Tarea 1", Status = EJobStatus.InProgress },
            new JobModelView { Id= 2, Description = "Tarea 2", Status = EJobStatus.InProgress },
            new JobModelView { Id= 3, Description = "Tarea 3", Status = EJobStatus.Pending},
            new JobModelView { Id= 4, Description = "Tarea 4", Status = EJobStatus.Pending },
            new JobModelView { Id= 5, Description = "Tarea 5", Status = EJobStatus.Completed },
            new JobModelView { Id= 5, Description = "Tarea 6", Status = EJobStatus.Completed },

        };

        public Task AddJobAsync(JobModelView job)
        {
            Task task = Task.Run(() => jobsList.Add(job));
            return task;
        }

        public Task DeleteJobAsync(int jobId)
        {
            return Task.Run(() => jobsList.Remove(jobsList.Where(x => x.Id == jobId).First()));
        }

        public Task<List<JobModelView>> GetAllJobsAsync()
        {
            return Task.FromResult(jobsList);
        }

        public Task<JobModelView> GetJobByIdAsync(int jobId)
        {
            return Task.Run(() =>jobsList.Where(x => x.Id == jobId).First());
        }

        public Task UpdateJobAsync(JobModelView job)
        {
            return Task.Run(() =>
            {
                var existingJob = jobsList.Where(x => x.Id == job.Id).First();
                existingJob.Description = job.Description;
                existingJob.Status = job.Status;
            });
        }
    }
}
