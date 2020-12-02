using System.Collections.Generic;
using System.Threading.Tasks;
using Edialsoft.Domain._Base;

namespace Edialsoft.Domain.Person
{
    public interface IPersonRepository : IRepository<Person>
    {
        Task<Person> GetByPhone(string phone);
    }
}
