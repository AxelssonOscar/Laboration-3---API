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
    public class Link : Controller
    {
        private Services.ILink _linkRepository;

        public Link(Services.ILink linkRepository)
        {
            this._linkRepository = linkRepository;
        }

        [HttpGet("{search}/{searchString}")]
        public IActionResult Search(string searchString)
        {
            IEnumerable<Models.Link> searchResult = _linkRepository.Search(searchString);

            if (searchResult.Any())
            {
                return Ok(searchResult);
            }
            return NotFound();
        }


        [HttpGet("{id}")]
        public IActionResult GetAllLinksForSpecificPerson(int id)
        {
            IEnumerable<Models.Link> searchResult = _linkRepository.GetAllLinksForSpecificPerson(id);

            if (searchResult.Any())
            {
                return Ok(searchResult);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> AddNewInterest(Models.Link newLink)
        {
            try
            {
                if (newLink == null)
                {
                    return BadRequest();
                }
                var addedInterest = await _linkRepository.AddNewLink(newLink);
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
