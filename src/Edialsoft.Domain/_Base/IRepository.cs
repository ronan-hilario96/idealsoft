using System.Collections.Generic;
using System.Threading.Tasks;

namespace Edialsoft.Domain._Base
{
    public interface IRepository<T>
    {
        Task<T> GetById(int id);

        Task<List<T>> GetAll();

        Task Add(T entity);
        void Delete(T entity);
    }
}
