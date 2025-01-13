namespace ProjectName.Domain.Repositories
{
    public interface IDbTransactionProvider
    {
        Task BeginTransactionAsync();

        Task CommitTransactionAsync();

        Task RollbackTransactionAsync();
    }
}
