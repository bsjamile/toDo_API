using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoMakersCode.ToDoList.Application.Models;
using WoMakersCode.ToDoList.Core.Entities;

namespace WoMakersCode.ToDoList.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TaskRequest, TaskDetail>()
                .ForMember(dest => dest.IdTaskList, fonte => fonte.MapFrom(src => src.IdTaskList))
                .ForMember(dest => dest.Executado, fonte => fonte.MapFrom(src => src.Executado))
                .ForMember(dest => dest.DataHora, fonte => fonte.MapFrom(src => src.DataHora))
                .ForMember(dest => dest.Descricao, fonte => fonte.MapFrom(src => src.Descricao));

            CreateMap<TaskListRequest, TaskList>()
                .ForMember(dest => dest.ListName, fonte => fonte.MapFrom(src => src.ListName));

            CreateMap<TaskList, TaskListResponse>()
                .ForMember(dest => dest.ListName, fonte => fonte.MapFrom(src => src.ListName))
                .ForMember(dest => dest.Id, fonte => fonte.MapFrom(src => src.Id))
                .ForMember(dest => dest.Details, fonte => fonte.MapFrom(src => src.Details));

            CreateMap<TaskDetail, TaskResponse>()
                .ForMember(dest => dest.DataHora, fonte => fonte.MapFrom(src => src.DataHora))
                .ForMember(dest => dest.Executado, fonte => fonte.MapFrom(src => src.Executado))
                .ForMember(dest => dest.Id, fonte => fonte.MapFrom(src => src.Id))
                .ForMember(dest => dest.IdTaskList, fonte => fonte.MapFrom(src => src.IdTaskList))
                .ForMember(dest => dest.Descricao, fonte => fonte.MapFrom(src => src.Descricao));

            CreateMap<TaskListInsertRequest, TaskList>()
                .ForMember(dest => dest.ListName, fonte => fonte.MapFrom(src => src.ListName))
                .ForMember(dest => dest.IdColor, fonte => fonte.MapFrom(src => src.IdColor));
        }
    }
}
