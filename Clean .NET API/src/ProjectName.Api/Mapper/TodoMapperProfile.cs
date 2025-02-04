using AutoMapper;
using ProjectName.Api.DTOs.Todo;
using ProjectName.Domain.Entities;

namespace ProjectName.Api.Mapper
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
