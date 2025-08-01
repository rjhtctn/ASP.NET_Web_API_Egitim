﻿using Entities.DataTransferObjects;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;
using System.Text.Json;

namespace Presentation.Controllers
{
    [ServiceFilter(typeof(LogFilterAttribute))]
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
        public async Task<IActionResult> GetAllBooksAsync([FromQuery]BookParameters bookParameters)
        {

            var pagedResult = await _manager
                .BookService
                .GetAllBooksAsync(bookParameters, false);

            Response.Headers["X-Pagination"] = JsonSerializer.Serialize(pagedResult.metaData);
            return Ok(pagedResult.books);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneBookAsync([FromRoute(Name = "id")] int id)
        {
                var book = await _manager.BookService.GetOneBookByIdAsync(id, false);
                return Ok(book);
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost]
        public async Task<IActionResult> CreateOneBookAsync([FromBody] BookDtoForInsertion bookDto)
        {
                var book = await _manager.BookService.CreateOneBookAsync(bookDto);
                return StatusCode(201, book);
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOneBookAsync([FromRoute(Name = "id")] int id,
            [FromBody] BookDtoForUptade bookDto)
        {
                await _manager.BookService.UpdateOneBookAsync(id, bookDto, false);
                return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOneBookAsync([FromRoute(Name = "id")] int id)
        {
                await _manager.BookService.DeleteOneBookAsync(id, false);
                return NoContent();
        }

        [HttpPatch("{id:int}")]
        public async Task<IActionResult> PartiallyUpdateOneBookAsync([FromRoute(Name = "id")] int id,
            [FromBody] JsonPatchDocument<BookDtoForUptade> bookPatch)
        {
            if (bookPatch is null)
            {
                return BadRequest();
            }
            var result = await _manager.BookService.GetOnBookForPatchAsync(id, false);
            bookPatch.ApplyTo(result.bookDtoForUptade, ModelState);
            TryValidateModel(result.bookDtoForUptade);
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            await _manager.BookService.SaveChangesForPatchAsync(result.bookDtoForUptade, result.book);
            return NoContent();
        }
    }
}