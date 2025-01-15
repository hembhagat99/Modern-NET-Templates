using System.Linq.Expressions;
using AutoMapper;

namespace SampleProj.Domain.Extensions
{
    public static class IMappingExpressionExtensions
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
