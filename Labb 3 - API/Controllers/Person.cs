using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb_3___API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Person : ControllerBase
    {
        private Services.IPerson _personRepository;
        private Services.IInterest _interestRepository;
    
        public Person(Services.IPerson PersonRepository, Services.IInterest InterestRepository)
        {
            this._personRepository = PersonRepository;
            this._interestRepository = InterestRepository;
        }

        [HttpGet]
        public IActionResult GetAllPersons()
        {
            return Ok(_personRepository.GetAllPersons());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetSinglePerson(int id)
        {
            var person = await _personRepository.GetPerson(id);

            if(person != null)
            {
                return Ok(person);
            }

            return NotFound("Person was not found");
        }

        [HttpGet("{search}/{searchString}")]
        public IActionResult Search(string searchString)
        {
            IEnumerable<Models.Person> searchResult = _personRepository.Search(searchString);

            if(searchResult.Any())
            {
                return Ok(searchResult);
            }
            return NotFound();
        }

        




    }
}
