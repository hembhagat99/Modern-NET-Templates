using AutoMapper;
using SampleProj.Domain.Entities;
using SampleProj.Infrastructure.DataModels;

namespace SampleProj.Infrastructure.Mapper
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
