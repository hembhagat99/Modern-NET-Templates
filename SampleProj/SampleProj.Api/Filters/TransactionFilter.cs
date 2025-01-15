using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SampleProj.Domain.Repositories;

namespace SampleProj.Api.Filters
{
    internal class TransactionFilter(IDbTransactionProvider dbTransactionProvider) : ActionFilterAttribute
    {
        private readonly IDbTransactionProvider _dbTransactionService = dbTransactionProvider;

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.HttpContext.Request.Method == HttpMethod.Get.Method)
            {
                await next.Invoke();
            }
            else
            {
                await _dbTransactionService.BeginTransactionAsync();

                var executedContext = await next.Invoke();

                if(executedContext.Exception == null)
                    await _dbTransactionService.CommitTransactionAsync();
                else
                    await _dbTransactionService.RollbackTransactionAsync();
            }
        }
    }

    internal class TransactionTypeFilter : TypeFilterAttribute
    {
        public TransactionTypeFilter() : base(typeof(TransactionFilter))
        {
        }
    }
}
