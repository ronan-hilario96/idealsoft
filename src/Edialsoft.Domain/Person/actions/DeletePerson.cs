using System.Threading.Tasks;

namespace Edialsoft.Domain.Person.actions
{
    public class DeletePerson
    {
        private readonly IPersonRepository _personRepository;

        public DeletePerson(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task Delete(int idPerson)
        {
            var person = await _personRepository.GetById(idPerson);

            if (person != null)
            {
                _personRepository.Delete(person);
            }
        }
    }
}
