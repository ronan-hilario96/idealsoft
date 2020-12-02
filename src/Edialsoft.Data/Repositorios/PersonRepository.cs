using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Edialsoft.Data.Context;
using Edialsoft.Domain.Person;
using Microsoft.EntityFrameworkCore;

namespace Edialsoft.Data.Repositorios
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Task<Person> GetByPhone(string phone)
        {
            return _context.Set<Person>().Where(x => x.Phone == phone).FirstOrDefaultAsync();
        }
    }
}
