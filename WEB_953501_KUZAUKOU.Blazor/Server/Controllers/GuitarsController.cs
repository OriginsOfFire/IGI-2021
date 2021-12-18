using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEB_953501_KUZAUKOU.Data;
using WEB_953501_KUZAUKOU.Entities;

namespace WEB_953501_KUZAUKOU.Blazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuitarsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GuitarsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Guitars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Guitar>>> GetGuitars(int? group)
        {
            var guitars = _context.Guitars.Where(d => !group.HasValue || d.GuitarGroupId == group.Value);
            return await guitars.ToListAsync();
        }

        // GET: api/Guitars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Guitar>> GetGuitar(int id)
        {
            var guitar = await _context.Guitars.FindAsync(id);

            if (guitar == null)
            {
                return NotFound();
            }

            return guitar;
        }

        // PUT: api/Guitars/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGuitar(int id, Guitar guitar)
        {
            if (id != guitar.GuitarId)
            {
                return BadRequest();
            }

            _context.Entry(guitar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GuitarExists(id))
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

        // POST: api/Guitars
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Guitar>> PostGuitar(Guitar guitar)
        {
            _context.Guitars.Add(guitar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGuitar", new { id = guitar.GuitarId }, guitar);
        }

        // DELETE: api/Guitars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGuitar(int id)
        {
            var guitar = await _context.Guitars.FindAsync(id);
            if (guitar == null)
            {
                return NotFound();
            }

            _context.Guitars.Remove(guitar);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GuitarExists(int id)
        {
            return _context.Guitars.Any(e => e.GuitarId == id);
        }
    }
}
