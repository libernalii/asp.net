using hw_2.Models;
using hw_2.Services;
using Microsoft.AspNetCore.Mvc;

namespace hw_2.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly BookService _service;

        public BooksController(BookService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var book = _service.GetById(id);
            return book == null ? NotFound() : Ok(book);
        }

        [HttpPost]
        public IActionResult Add(Book book)
        {
            var result = _service.Add(book);
            if (!result) return BadRequest("Description contains forbidden words");

            return Ok(book);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Book book)
        {
            var result = _service.Update(id, book);
            if (!result) return BadRequest("Invalid data or forbidden words");

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _service.Delete(id);
            if (!result) return NotFound();

            return Ok();
        }
    }
}
