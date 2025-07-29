using Entities.DataTransferObjects;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IServiceManager _manager;
        public BooksController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
                var books = _manager.BookService.GetAllBooks(false);
                return Ok(books);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneBook([FromRoute(Name = "id")] int id)
        {
                var book = _manager.BookService.GetOneBookById(id, false);
                return Ok(book);
        }

        [HttpPost]
        public IActionResult CreateOneBook([FromBody] BookDtoForInsertion bookDto)
        {
                if (bookDto is null)
                {
                    return BadRequest();
                }
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
                var book = _manager.BookService.CreateOneBook(bookDto);
                return StatusCode(201, book);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOneBook([FromRoute(Name = "id")] int id,
            [FromBody] BookDtoForUptade bookDto)
        {
                if (bookDto is null)
                {
                    return BadRequest();
                }
                if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
                _manager.BookService.UpdateOneBook(id, bookDto, false);
                return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneBook([FromRoute(Name = "id")] int id)
        {
                _manager.BookService.DeleteOneBook(id, false);
                return NoContent();
        }

        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdateOneBook([FromRoute(Name = "id")] int id,
            [FromBody] JsonPatchDocument<BookDtoForUptade> bookPatch)
        {
            if (bookPatch is null)
            {
                return BadRequest();
            }
            var result = _manager.BookService.GetOnBookForPatch(id, false);
            bookPatch.ApplyTo(result.bookDtoForUptade, ModelState);
            TryValidateModel(result.bookDtoForUptade);
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            _manager.BookService.SaveChangesForPatch(result.bookDtoForUptade, result.book);
            return NoContent();
        }
    }
}