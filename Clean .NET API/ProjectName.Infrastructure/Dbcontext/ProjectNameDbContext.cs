using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectName.Infrastructure.Dbcontext.TypeConfigurations;

namespace ProjectName.Infrastructure.Dbcontext
{
    internal class ProjectNameDbContext(DbContextOptions<ProjectNameDbContext> options)
        : IdentityDbContext<IdentityUser>(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TodoDataModelTypeConfiguration).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
