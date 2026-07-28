using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.Application.DTOs.Project;
using TaskManager.Application.DTOs.TaskItem;
using TaskManager.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TaskManager.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Project, ProjectDto>();

            CreateMap<CreateProjectDto, Project>();

            CreateMap<UpdateProjectDto, Project>();

            CreateMap<TaskItem, TaskItemDto>()
    .ForMember(
        dest => dest.ProjectName,
        opt => opt.MapFrom(src => src.Project.Name)
    );

            CreateMap<CreateTaskItemDto, TaskItem>();

            CreateMap<UpdateTaskItemDto, TaskItem>();
        }
    }
}
