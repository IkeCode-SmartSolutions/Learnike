using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Learnike.Data;
using Learnike.Models;

namespace Learnike.Api.Controllers
{
    /// <summary>
    /// Book operations
    /// </summary>
    [Route("api/[controller]")]
    public class BooksController : BaseApiController
    {
        ApplicationDbContext _context;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="context"></param>
        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// (async) Get books method
        /// </summary>
        /// <returns>Task with books list</returns>
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            var books = _context.Books.ToList();
            return books;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// Add new Book
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        /// <summary>
        /// Update a existing Book
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        /// <summary>
        /// Delete a Book
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
