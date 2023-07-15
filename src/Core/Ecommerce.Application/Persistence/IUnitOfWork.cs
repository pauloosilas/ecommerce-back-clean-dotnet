namespace Ecommerce.Application.Persistence;

public interface UInitOfWork: IDisposable
{
    IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : class;

    Task<int> Complete();
}