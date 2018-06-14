using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetsizeAPI.Data;
using NetsizeAPI.Models;

namespace NetsizeAPI.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/AppTasks")]
    public class AppTasksController : Controller
    {
        private readonly NetsizeDbContext _context;

        public AppTasksController(NetsizeDbContext context)
        {
            _context = context;
        }

        // GET: api/AppTasks
        [HttpGet]
        public IEnumerable<AppTask> GetTasks()
        {
            return _context.Tasks;
        }

        // GET: api/AppTasks/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppTask([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var appTask = await _context.Tasks.SingleOrDefaultAsync(m => m.Id == id);

            if (appTask == null)
            {
                return NotFound();
            }

            return Ok(appTask);
        }

        // PUT: api/AppTasks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppTask([FromRoute] int id, [FromBody] AppTask appTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != appTask.Id)
            {
                return BadRequest();
            }

            _context.Entry(appTask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppTaskExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/AppTasks
        [HttpPost]
        public async Task<IActionResult> PostAppTask([FromBody] AppTask appTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Tasks.Add(appTask);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppTask", new { id = appTask.Id }, appTask);
        }

        // DELETE: api/AppTasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppTask([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var appTask = await _context.Tasks.SingleOrDefaultAsync(m => m.Id == id);
            if (appTask == null)
            {
                return NotFound();
            }

            _context.Tasks.Remove(appTask);
            await _context.SaveChangesAsync();

            return Ok(appTask);
        }

        private bool AppTaskExists(int id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }
    }
}