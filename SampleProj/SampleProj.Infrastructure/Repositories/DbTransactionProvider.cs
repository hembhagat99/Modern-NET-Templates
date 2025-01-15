using Microsoft.EntityFrameworkCore.Storage;
using SampleProj.Domain.Repositories;
using SampleProj.Infrastructure.Dbcontext;

namespace SampleProj.Infrastructure.Repositories
{
    internal class DbTransactionProvider(SampleProjDbContext dbContext) : IDbTransactionProvider
    {
        private readonly SampleProjDbContext _dbContext = dbContext;

        private IDbContextTransaction? transaction;

        public async Task BeginTransactionAsync()
        {
            transaction = await _dbContext.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            await transaction?.CommitAsync();
            transaction?.Dispose();
        }

        public async Task RollbackTransactionAsync()
        {
            await transaction?.RollbackAsync();
            transaction?.Dispose();
        }
    }
}
