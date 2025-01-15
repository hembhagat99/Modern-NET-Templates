using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SampleProj.Infrastructure.Dbcontext.TypeConfigurations;

namespace SampleProj.Infrastructure.Dbcontext
{
    internal class SampleProjDbContext(DbContextOptions<SampleProjDbContext> options)
        : IdentityDbContext<IdentityUser>(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TodoDataModelTypeConfiguration).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
