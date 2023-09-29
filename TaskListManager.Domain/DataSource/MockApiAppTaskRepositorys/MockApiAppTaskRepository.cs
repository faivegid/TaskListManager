using Newtonsoft.Json;
using TaskListManager.Domain.AppTasks;
using TaskListManager.Domain.DataSource.MockApi;

namespace TaskListManager.Domain.DataSource.MockApiAppTaskRepositorys
{
    public class MockApiAppTaskRepository : IAppTaskRepository
    {
        private readonly IMockapiClient _mockapiClient;

        public MockApiAppTaskRepository(IMockapiClient mockapiClient)
        {
            _mockapiClient = mockapiClient;
        }

        public async Task<AppTask> Get(int id)
        {
            var response = await _mockapiClient.SendAsync(HttpMethod.Get, $"api/v1/tasks/{id}");

            var data = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<AppTask>(data);
            return result;
        }

        public async Task<List<AppTask>> Get()
        {
            var response = await _mockapiClient.SendAsync(HttpMethod.Get, "api/v1/tasks");

            var data = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<AppTask>>(data);
            return result;
        }

        public async Task<AppTask> Create(AppTask newTask)
        {
            var response = await _mockapiClient.SendAsync(HttpMethod.Post, "api/v1/tasks", newTask);

            var data = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<AppTask>(data);
            return result;
        }

        public async Task<AppTask> Update(AppTask updatedTask)
        {
            var response = await _mockapiClient.SendAsync(HttpMethod.Patch, $"api/v1/tasks/{updatedTask.Id}", updatedTask);

            var data = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<AppTask>(data);
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var response = await _mockapiClient.SendAsync(HttpMethod.Delete, $"api/v1/tasks/{id}");

            var data = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<AppTask>(data);
            return true;
        }
    }
}
