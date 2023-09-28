﻿using AutoMapper;
using TaskListManager.AppService.Tasks.Dtos;
using TaskListManager.Domain.Tasks;

namespace TaskListManager.AppService
{
    public class TaskListManagerMapperProfile : Profile
    {
        public TaskListManagerMapperProfile()
        {
            CreateMap<AppTask, AppTaskDto>()
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.StartDate.AddDays(src.ElapsedTime)))
                .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => src.StartDate.AddDays(src.AllottedTime)))
                .ForMember(dest => dest.DaysOverdue, opt => opt.MapFrom(src => src.Status ?0: src.ElapsedTime - src.AllottedTime ))
                .ForMember(dest => dest.DaysLate, opt => opt.MapFrom(src => src.Status ? src.AllottedTime - src.ElapsedTime : 0))
                .ReverseMap();
        }
    }
}