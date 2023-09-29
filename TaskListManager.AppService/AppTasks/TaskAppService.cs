using AutoMapper;

namespace TaskListManager.AppService.AppTasks
{
    public class TaskAppService : ITaskAppService
    {
        private readonly IMapper _mapper;

        public TaskAppService(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
