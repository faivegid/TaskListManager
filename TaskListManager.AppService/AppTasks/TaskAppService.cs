using AutoMapper;
using TaskListManager.Domain.AppTasks;
using TaskListManager.Shared.AppTasks;
using TaskListManager.Shared.AppTasks.Dtos;
using TaskListManager.Shared.Utility;

namespace TaskListManager.AppService.AppTasks
{
    public class TaskAppService : ITaskAppService
    {
        private readonly IMapper _mapper;
        private readonly IAppTaskRepository _taskRepository;

        public TaskAppService(IMapper mapper, IAppTaskRepository taskRepository)
        {
            _mapper = mapper;
            _taskRepository = taskRepository;
        }

        public async Task<AppTaskDto> GetTask(string id)
        {
            var task = await _taskRepository.Get(id);
            var taskDto = _mapper.Map<AppTaskDto>(task);

            return taskDto;
        }

        public async Task<List<AppTaskDto>> GetTasks()
        {
            var tasks = await _taskRepository.Get();
            var taskDtos = _mapper.Map<List<AppTaskDto>>(tasks);

            return taskDtos;
        }

        public async Task<AppTaskDto> CreateTask(TaskCreateRto createRequest)
        {
            var newTask = new AppTask()
            {
                Name = createRequest.Name,
                Description = createRequest.Description,
                StartDate = createRequest.StartDate,
                Status = false,
                AllottedTime = createRequest.AllottedTime,
                ElapsedTime = 0
            };

            var savedTask = await _taskRepository.Create(newTask);
            return _mapper.Map<AppTaskDto>(savedTask);
        }

        public async Task<AppTaskDto> UpdateTask(string id, TaskUpdateRto updateRto)
        {
            var appTask = await _taskRepository.Get(id);
            var startDate = appTask.StartDate;

            UpdateHelper.UpdateModelProperties(appTask, updateRto);
            if(startDate !=  appTask.StartDate)
            {
                appTask.ElapsedTime = 0;
            }

            var updatedTask = await _taskRepository.Update(appTask);
            return _mapper.Map<AppTaskDto>(updatedTask);
        }

        public async Task<bool> DeleteTask(string id)
        {
            return await _taskRepository.Delete(id);
        }
    }
}
