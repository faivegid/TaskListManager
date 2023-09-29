using AutoMapper;
using TaskListManager.Domain.AppTasks;
using TaskListManager.Shared.AppTasks.Dtos;

namespace TaskListManager.AppService
{
    public class TaskListManagerMapperProfile : Profile
    {
        public TaskListManagerMapperProfile()
        {
            CreateMap<AppTask, AppTaskDto>()
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.StartDate.AddDays(src.ElapsedTime)))
                .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => src.StartDate.AddDays(src.AllottedTime)))
                .ForMember(dest => dest.DaysOverdue, opt => opt.MapFrom(src => src.Status ? 0 : Math.Abs(src.ElapsedTime - src.AllottedTime)))
                .ForMember(dest => dest.DaysLate, opt => opt.MapFrom(src => src.Status ? Math.Abs(src.AllottedTime - src.ElapsedTime) : 0))
                .ReverseMap();
        }
    }
}
