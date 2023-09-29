using AutoMapper;
using System.Threading.Tasks;
using TaskListManager.Domain.AppTasks;
using TaskListManager.Shared.AppTasks.Dtos;

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

        public async Task<AppTaskDto> GetTask(int id)
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
    }
}
