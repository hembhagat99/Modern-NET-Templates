using Microsoft.EntityFrameworkCore.Storage;
using ProjectName.Domain.Repositories;
using ProjectName.Infrastructure.Dbcontext;

namespace ProjectName.Infrastructure.Repositories
{
    internal class DbTransactionProvider(ProjectNameDbContext dbContext) : IDbTransactionProvider
    {
        private readonly ProjectNameDbContext _dbContext = dbContext;

        private IDbContextTransaction? transaction;

        public async Task BeginTransactionAsync()
        {
            transaction = await _dbContext.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            await transaction!.CommitAsync();
            transaction!.Dispose();
        }

        public async Task RollbackTransactionAsync()
        {
            await transaction!.RollbackAsync();
            transaction!.Dispose();
        }
    }
}
