using System.Threading.Tasks;
using Edialsoft.Domain._Base;

namespace Edialsoft.Domain.Person.actions
{
    public class SavePerson
    {
        private readonly IPersonRepository _personRepository;
        public SavePerson(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task Save(PersonDto personDto)
        {
            Person person = null;

            var hasPerson = await _personRepository.GetByPhone(personDto.Phone.Trim());

            RuleValidator
                .New()
                .When(hasPerson != null && hasPerson.Id != personDto.Id, Resource.PhoneAlreadyRegistred)
                .TriggerException();

            if (personDto.Id == 0)
            {
                person = new Person(personDto.FirstName, personDto.LastName, personDto.Phone);

                await _personRepository.Add(person);

                return;
            }

            person = await _personRepository.GetById(personDto.Id);

            person.AlterFirstName(personDto.FirstName);
            person.AlterLastName(personDto.LastName);
            person.AlterPhone(personDto.Phone);
        }
    }
}
