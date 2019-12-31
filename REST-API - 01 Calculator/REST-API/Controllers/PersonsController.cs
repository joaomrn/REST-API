using Microsoft.AspNetCore.Mvc;
using RESTAPI.Model;
using RESTAPI.Business;

namespace REST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private IPersonBusiness _personBusiness;

        public PersonsController(IPersonBusiness personBusiness)
        {
            _personBusiness = personBusiness;
        }

        // GET api/Persons
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_personBusiness.FindAll());
        }

        // GET api/Persons/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var person = _personBusiness.FindById(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        // POST api/Persons
        [HttpPost]
        public ActionResult Post([FromBody]Person person)
        {
            if (person == null) return BadRequest();
            return new ObjectResult(_personBusiness.Create(person));
        }

        // PUT api/Persons
        [HttpPut]
        public ActionResult Put([FromBody]Person person)
        {
            if (person == null) return BadRequest();
            var updatedPerson = _personBusiness.Update(person);
            if (updatedPerson == null) return NoContent();
            return new ObjectResult(updatedPerson);
        }

        // DELETE api/Persons/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _personBusiness.Delete(id);
            return NoContent();
        }
    }
}
