using System.Collections.Generic;

namespace TaxiFair.Domain.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T Get(string id);
    }
}