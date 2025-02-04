using System.Linq.Expressions;
using AutoMapper;

namespace ProjectName.Domain.Extensions
{
    public static class MappingExpressionExtensions
    {
        public static IMappingExpression<TSrc, TDest> ForProperty<TSrc, TDest, TSrcMember, TDestMember>(
            this IMappingExpression<TSrc, TDest> mappingExpression,
            Expression<Func<TDest, TDestMember>> destMemberExpression,
            Expression<Func<TSrc, TSrcMember>> srcMemberExpression)
        {
            return mappingExpression
                .ForMember(destMemberExpression, opt => opt.MapFrom(srcMemberExpression));
        }
    }
}
