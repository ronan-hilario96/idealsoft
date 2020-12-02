using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Edialsoft.Data.Context;
using Edialsoft.Domain._Base;
using Microsoft.EntityFrameworkCore;

namespace Edialsoft.Data.Repositorios
{
    public class BaseRepository<T> : IRepository<T> where T : Entity
    {
        protected readonly ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<T> GetById(int id)
        {
            return _context.Set<T>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public Task<List<T>> GetAll()
        {
            return _context.Set<T>().ToListAsync();
        }

        public async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
    }
}
