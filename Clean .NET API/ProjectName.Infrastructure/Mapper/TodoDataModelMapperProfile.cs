using AutoMapper;
using ProjectName.Domain.Entities;
using ProjectName.Infrastructure.DataModels;

namespace ProjectName.Infrastructure.Mapper
{
    public class TodoDataModelMapperProfile : Profile
    {
        public TodoDataModelMapperProfile()
        {
            CreateMap<Todo, TodoDataModel>()
                .ReverseMap();
        }
    }
}
