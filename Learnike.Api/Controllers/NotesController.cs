using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Learnike.Data;
using Learnike.Models;
using Microsoft.EntityFrameworkCore;

namespace Learnike.Api.Controllers
{
    /// <summary>
    /// 'Note' operations
    /// </summary>
    [Route("api/[controller]")]
    public class NotesController : BaseApiController
    {
        ApplicationDbContext _context;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="context">Injected DbContext</param>
        public NotesController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all Books
        /// </summary>
        /// <returns>Book list</returns>
        [HttpGet]
        public IEnumerable<Note> Get()
        {
            var notes = _context.Notes.ToList();
            return notes;
        }

        /// <summary>
        /// Get specific Note
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Note instance</returns>
        /// <see cref="Note"/>
        /// <response code="200">Note found</response>
        /// <response code="404">Note not found</response>
        /// <response code="500">Oops! Internal server error detected!</response>
        [HttpGet("{id}")]
        [Produces(typeof(Note))]
        [ProducesResponseType(typeof(Note), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(void), 500)]
        public IActionResult Get(int id)
        {
            var result = _context.Notes.FirstOrDefault(i => i.Id == id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Add new Note
        /// </summary>
        /// <param name="note"></param>
        [HttpPost]
        public void Post([FromBody]Note note)
        {
            _context.Add(note);
            _context.SaveChanges();
        }

        /// <summary>
        /// Update a existing Note
        /// </summary>
        /// <param name="id"></param>
        /// <param name="note"></param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Note note)
        {
            _context.Attach(note).State = EntityState.Modified;
            _context.SaveChanges();
        }

        /// <summary>
        /// Delete a Note
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var book = _context.Notes.FirstOrDefault(i => i.Id == id);
            _context.Remove(book);
            _context.SaveChanges();
        }
    }
}
