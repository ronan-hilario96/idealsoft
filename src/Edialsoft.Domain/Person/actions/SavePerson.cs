using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Edialsoft.Domain._Base;

namespace Edialsoft.Domain.Person.actions
{
    public class SavePerson
    {
        private readonly IPersonRepository _personRepository;
        public List<string> ErrorList = new List<string>();
        public SavePerson(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task Save(PersonDto personDto)
        {
            Person person = null;

            var hasPerson = await _personRepository.GetByPhone(personDto.Phone.Trim());

            var errorList = RuleValidator
                .New()
                .When(hasPerson != null && hasPerson.Id != personDto.Id, Resource.PhoneAlreadyRegistred)
                ._ErrosMsg;

            ErrorList.AddRange(errorList);

            if (ErrorList.Any())
            {
                return;
            }

            if (personDto.Id == 0)
            {
                person = new Person(personDto.FirstName, personDto.LastName, personDto.Phone);

                ErrorList.AddRange(person.Errors);

                if (ErrorList.Any())
                    return;

                await _personRepository.Add(person);

                return;
            }

            person = await _personRepository.GetById(personDto.Id);

            person.AlterFirstName(personDto.FirstName);
            person.AlterLastName(personDto.LastName);
            person.AlterPhone(personDto.Phone);

            ErrorList.AddRange(person.Errors);
        }
    }
}
