using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Learnike.Data;
using Learnike.Models;
using Microsoft.EntityFrameworkCore;

namespace Learnike.Api.Controllers
{
    /// <summary>
    /// 'Book' operations
    /// </summary>
    [Route("api/[controller]")]
    public class BooksController : BaseApiController
    {
        IRepository<Book> _repository;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="repository"></param>
        public BooksController(IRepository<Book> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Get all Books
        /// </summary>
        /// <returns>Book list</returns>
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            var books = _repository.Get(null, 0, 10, null);

            return books;
        }

        /// <summary>
        /// Get specific Book
        /// </summary>
        /// <param name="id"></param>
        /// <returns><see cref="Book"/> instance</returns>
        /// <response code="200">Book found</response>
        /// <response code="404">Book not found</response>
        /// <response code="500">Oops! Internal server error detected!</response>
        [HttpGet("{id}")]
        [Produces(typeof(Book))]
        [ProducesResponseType(typeof(Book), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(void), 500)]
        public IActionResult Get(int id)
        {
            var result = _repository.Get(id, null);
            if (result == null)
                return NotFound();

            return Json(result);
        }

        /// <summary>
        /// Add new Book
        /// </summary>
        /// <param name="book"></param>
        [HttpPost]
        public void Post([FromBody]Book book)
        {
            _repository.Upsert(book);
        }

        /// <summary>
        /// Update a existing Book
        /// </summary>
        /// <param name="id"></param>
        /// <param name="book"></param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Book book)
        {
            _repository.Upsert(book);
        }

        /// <summary>
        /// Delete a Book
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.Remove(id);
        }
    }
}
