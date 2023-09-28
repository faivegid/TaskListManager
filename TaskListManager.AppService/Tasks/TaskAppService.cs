using AutoMapper;

namespace TaskListManager.AppService.Tasks
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
