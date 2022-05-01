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
    public class Interest : ControllerBase
    {
        private Services.IInterest _interestRepository;

        public Interest(Services.IInterest InterestRepository)
        {
            this._interestRepository = InterestRepository;
        }


        [HttpGet("{id}")]
        public IActionResult GetAllInterestsForSpecificPerson(int id)
        {
            IEnumerable<Models.Interest> searchResult = _interestRepository.GetAllInterestsForSpecificPerson(id);

            if (searchResult.Any())
            {
                return Ok(searchResult);
            }
            return NotFound();
        }

        [HttpGet("{search}/{name}")]
        public IActionResult Search(string name)
        {
            IEnumerable<Models.Interest> searchResult = _interestRepository.Search(name);

            if(searchResult.Any())
            {
                return Ok(searchResult);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewInterest(Models.Interest newInterest)
        {
            try
            {
                if (newInterest == null)
                {
                    return BadRequest();
                }
                var addedInterest = await _interestRepository.AddNewInterest(newInterest);
                return CreatedAtAction(nameof(addedInterest), new { id = addedInterest.Id }, addedInterest);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    " Error to post new interest to Database: " + e.Message);
            }
        }


    }
}
