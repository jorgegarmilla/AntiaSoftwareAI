using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using WebApp.Client.ModelView;

namespace WebApp.Client.Services
{
    public interface IApiProxy
    {
        public Task<List<JobModelView>> GetJobs();

        public Task AddJob(JobModelView job);

        public Task LogOut();
    }

    public class ApiProxy : IApiProxy
    {
        private readonly HttpClient _httpClient;    

        public ApiProxy(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<JobModelView>> GetJobs()
        {
            return await _httpClient!.GetFromJsonAsync<List<JobModelView>>("/api/jobs");
        }

        public async Task AddJob(JobModelView job)
        {
            await _httpClient!.PostAsJsonAsync<JobModelView>("/api/jobs", job);
        }

        public async Task LogOut()
        {
            var emptyContent = new StringContent("{}", Encoding.UTF8, "application/json");
            await _httpClient.PostAsync("/api/logout", emptyContent);
            //await _httpClient!.GetAsync("/web/logout");
        }
    }
}
