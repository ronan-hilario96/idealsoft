using System.Threading.Tasks;

namespace Edialsoft.Domain._Base
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
