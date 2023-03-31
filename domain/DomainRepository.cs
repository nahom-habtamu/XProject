namespace domain;
public interface DomainRepository<T>
{
    Task<T?> Get(string id);
    Task<string> Save(T entity);
}