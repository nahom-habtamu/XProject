using System.Threading.Tasks;

namespace domain;
public interface DomainRepository<T>
{
    Task<T?> Get(string id);
    Task Save(T entity);
}