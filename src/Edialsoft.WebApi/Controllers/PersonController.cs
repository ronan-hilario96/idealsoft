using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Edialsoft.Domain.Person;
using Edialsoft.Domain.Person.actions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Edialsoft.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _repository;
        private readonly SavePerson _savePerson;
        private readonly DeletePerson _deletePerson;

        public PersonController(SavePerson savePerson, DeletePerson deletePerson, IPersonRepository repository)
        {
            _savePerson = savePerson;
            _deletePerson = deletePerson;
            _repository = repository;
        }
        [HttpGet]
        [AllowAnonymous]
        [Route("")]
        public async Task<IActionResult> Get()
        {
            var person = await _repository.GetAll();
            return Ok(person);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("{personId}")]
        public async Task<IActionResult> Get(int personId)
        {
            var person = await _repository.GetById(personId);
            return Ok(person);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] PersonDto personDto)
        {
            await _savePerson.Save(personDto);
            return Ok();
        }

        [HttpDelete]
        [AllowAnonymous]
        [Route("{personId}")]
        public async Task<IActionResult> Delete(int personId)
        {
            await _deletePerson.Delete(personId);
            return Ok();
        }
    }
}
