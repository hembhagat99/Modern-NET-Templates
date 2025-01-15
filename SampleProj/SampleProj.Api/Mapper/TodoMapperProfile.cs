using AutoMapper;
using SampleProj.Api.DTOs.Todo;
using SampleProj.Domain.Entities;

namespace SampleProj.Api.Mapper
{
    public class TodoMapperProfile : Profile
    {
        public TodoMapperProfile()
        {
            CreateMap<TodoRequestDto, Todo>();

            CreateMap<Todo, TodoResponseDto>();
        }
    }
}
