namespace ProjectName.Domain.Repositories
{
    public interface IMigrationRepository
    {
        void ApplyPendingMigrations();
    }
}
