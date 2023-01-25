using System.Threading.Tasks;

namespace domain;
interface DomainRepository<T>
{
    Task<T> Get(string id);
    Task Save(T entity);
}