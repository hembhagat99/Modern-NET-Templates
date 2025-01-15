using Microsoft.EntityFrameworkCore;
using SampleProj.Domain.Repositories;
using SampleProj.Infrastructure.Dbcontext;

namespace SampleProj.Infrastructure.Repositories
{
    internal class MigrationRepository(SampleProjDbContext dbContext) : IMigrationRepository
    {
        private readonly SampleProjDbContext _dbContext = dbContext;

        public void ApplyPendingMigrations()
        {
            _dbContext.Database.Migrate();
        }
    }
}
