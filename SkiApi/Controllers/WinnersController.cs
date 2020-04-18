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
    public class WinnersController : ControllerBase
    {
        private readonly SkiApiContext _context;

        public WinnersController(SkiApiContext context)
        {
            _context = context;
        }

        // GET: api/Winners
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Winner>>> GetWinners()
        {
            return await _context.Winners.ToListAsync();
        }

        // GET: api/Winners/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Winner>> GetWinner(int id)
        {
            var winner = await _context.Winners.FindAsync(id);

            if (winner == null)
            {
                return NotFound();
            }

            return winner;
        }

        // PUT: api/Winners/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWinner(int id, Winner winner)
        {
            if (id != winner.Year)
            {
                return BadRequest();
            }

            _context.Entry(winner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WinnerExists(id))
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

        // POST: api/Winners
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Winner>> PostWinner(Winner winner)
        {
            _context.Winners.Add(winner);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (WinnerExists(winner.Year))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetWinner", new { id = winner.Year }, winner);
        }

        // DELETE: api/Winners/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Winner>> DeleteWinner(int id)
        {
            var winner = await _context.Winners.FindAsync(id);
            if (winner == null)
            {
                return NotFound();
            }

            _context.Winners.Remove(winner);
            await _context.SaveChangesAsync();

            return winner;
        }

        private bool WinnerExists(int id)
        {
            return _context.Winners.Any(e => e.Year == id);
        }
    }
}
