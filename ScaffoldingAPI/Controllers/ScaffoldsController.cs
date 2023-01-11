using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScaffoldingAPI.Data;
using ScaffoldingAPI.Models;

namespace ScaffoldingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScaffoldsController : ControllerBase
    {
        private readonly ScaffoldingAPIContext _context;

        public ScaffoldsController(ScaffoldingAPIContext context)
        {
            _context = context;
        }

        // GET: api/Scaffolds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Scaffold>>> GetScaffold()
        {
            return await _context.Scaffold.ToListAsync();
        }

        // GET: api/Scaffolds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Scaffold>> GetScaffold(int id)
        {
            var scaffold = await _context.Scaffold.FindAsync(id);

            if (scaffold == null)
            {
                return NotFound();
            }

            return scaffold;
        }

        // PUT: api/Scaffolds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScaffold(int id, Scaffold scaffold)
        {
            if (id != scaffold.ID)
            {
                return BadRequest();
            }

            _context.Entry(scaffold).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScaffoldExists(id))
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

        // POST: api/Scaffolds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Scaffold>> PostScaffold(Scaffold scaffold)
        {
            _context.Scaffold.Add(scaffold);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetScaffold", new { id = scaffold.ID }, scaffold);
        }

        // DELETE: api/Scaffolds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScaffold(int id)
        {
            var scaffold = await _context.Scaffold.FindAsync(id);
            if (scaffold == null)
            {
                return NotFound();
            }

            _context.Scaffold.Remove(scaffold);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ScaffoldExists(int id)
        {
            return _context.Scaffold.Any(e => e.ID == id);
        }
    }
}
