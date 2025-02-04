using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectName.Infrastructure.DataModels;

namespace ProjectName.Infrastructure.Dbcontext.TypeConfigurations
{
    internal class TodoDataModelTypeConfiguration : IEntityTypeConfiguration<TodoDataModel>
    {
        public void Configure(EntityTypeBuilder<TodoDataModel> builder)
        {
            builder.ToTable("Todos");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
