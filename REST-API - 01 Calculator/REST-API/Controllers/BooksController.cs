using Microsoft.AspNetCore.Mvc;
using RESTAPI.Business;
using RESTAPI.Data.VO;
using RESTAPI.Model;
using RESTAPI.Repository.Generic;

namespace RESTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        //Declaração do serviço usado
        private IBookBusiness _bookBusiness;

        public BooksController(IBookBusiness bookBusiness)
        {
            _bookBusiness = bookBusiness;
        }

        // GET api/Books
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_bookBusiness.FindAll());
        }

        // GET api/Books/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var book = _bookBusiness.FindById(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        // POST api/books
        [HttpPost]
        public ActionResult Post([FromBody]BookVO book)
        {
            if (book == null) return BadRequest();
            return new ObjectResult(_bookBusiness.Create(book));
        }

        // PUT api/books
        [HttpPut]
        public ActionResult Put([FromBody]BookVO book)
        {
            if (book == null) return BadRequest();
            var updatedbook = _bookBusiness.Update(book);
            if (updatedbook == null) return NoContent();
            return new ObjectResult(updatedbook);
        }

        // DELETE api/books/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _bookBusiness.Delete(id);
            return NoContent();
        }
    }
}
