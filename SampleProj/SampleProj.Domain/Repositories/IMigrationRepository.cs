namespace SampleProj.Domain.Repositories
{
    public interface IMigrationRepository
    {
        void ApplyPendingMigrations();
    }
}
