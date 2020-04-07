using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkiApi.Data;
using SkiApi.Models;

namespace SkiApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkiersController : ControllerBase
    {
        private readonly SkiApiContext _context;

        public SkiersController(SkiApiContext context)
        {
            _context = context;
        }

        // GET: api/Skiers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Skier>>> GetSkier()
        {
            return await _context.Skiers.ToListAsync();
        }

        // GET: api/Skiers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Skier>> GetSkier(Guid id)
        {
            var skier = await _context.Skiers.FindAsync(id);

            if (skier == null)
            {
                return NotFound();
            }

            return skier;
        }

        // PUT: api/Skiers/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSkier(Guid id, Skier skier)
        {
            if (id != skier.Id)
            {
                return BadRequest();
            }

            _context.Entry(skier).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SkierExists(id))
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

        // POST: api/Skiers
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Skier>> PostSkier(Skier skier)
        {
            _context.Skiers.Add(skier);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSkier", new { id = skier.Id }, skier);
        }

        // DELETE: api/Skiers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Skier>> DeleteSkier(Guid id)
        {
            var skier = await _context.Skiers.FindAsync(id);
            if (skier == null)
            {
                return NotFound();
            }

            _context.Skiers.Remove(skier);
            await _context.SaveChangesAsync();

            return skier;
        }

        private bool SkierExists(Guid id)
        {
            return _context.Skiers.Any(e => e.Id == id);
        }
    }
}
