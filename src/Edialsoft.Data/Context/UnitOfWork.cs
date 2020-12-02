using System;
using System.Threading.Tasks;
using Edialsoft.Domain._Base;

namespace Edialsoft.Data.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task Commit()
        {
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
