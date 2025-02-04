using Microsoft.EntityFrameworkCore;
using ProjectName.Domain.Repositories;
using ProjectName.Infrastructure.Dbcontext;

namespace ProjectName.Infrastructure.Repositories
{
    internal class MigrationRepository(ProjectNameDbContext dbContext) : IMigrationRepository
    {
        private readonly ProjectNameDbContext _dbContext = dbContext;

        public void ApplyPendingMigrations()
        {
            _dbContext.Database.Migrate();
        }
    }
}
