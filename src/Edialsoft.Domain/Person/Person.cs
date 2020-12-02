using System.Linq;
using System.Text.RegularExpressions;
using Edialsoft.Domain._Base;

namespace Edialsoft.Domain.Person
{
    public class Person : Entity
    {
        private readonly Regex _phoneRegex = new Regex(@"^\(\d{2}\)\s(\d{1}\s|\d{0})\d{4}-\d{4}$");
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string Phone { get; protected set; }

        public Person(string firstName, string lastName, string phone)
        {
            Errors = RuleValidator
                .New()
                .When(string.IsNullOrEmpty(firstName.Trim()), Resource.FirstNameIsNull)
                .When(string.IsNullOrEmpty(lastName.Trim()), Resource.LastNameIsNull)
                .When(string.IsNullOrEmpty(phone.Trim()), Resource.PhoneIsNull)
                .When(!_phoneRegex.Match(phone.Trim()).Success, Resource.PhoneInvalid)
                ._ErrosMsg;

            if (Errors.Any())
                return;

            FirstName = firstName.Trim();
            LastName = lastName.Trim();
            Phone = phone.Trim();
        }

        public void AlterFirstName(string firstName)
        {
            Errors = RuleValidator
                .New()
                .When(string.IsNullOrEmpty(firstName.Trim()), Resource.FirstNameIsNull)
                ._ErrosMsg;

            if (Errors.Any())
                return;

            FirstName = firstName.Trim();
        }

        public void AlterLastName(string lastName)
        {
            Errors = RuleValidator
                .New()
                .When(string.IsNullOrEmpty(lastName.Trim()), Resource.LastNameIsNull)
                ._ErrosMsg;

            if (Errors.Any())
                return;

            LastName = lastName.Trim();
        }

        public void AlterPhone(string phone)
        {
            Errors = RuleValidator
                .New()
                .When(string.IsNullOrEmpty(phone.Trim()), Resource.PhoneIsNull)
                .When(!_phoneRegex.Match(phone.Trim()).Success, Resource.PhoneInvalid)
                ._ErrosMsg;

            if (Errors.Any())
                return;

            Phone = phone.Trim();
        }
    }
}
