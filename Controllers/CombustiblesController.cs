using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WepApiGM.Context;
using WepApiGM.Models;

namespace WepApiGM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CombustiblesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CombustiblesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Combustibles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Combustible>>> GetCombustibles()
        {
            return await _context.Combustibles.ToListAsync();
        }

        // GET: api/Combustibles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Combustible>> GetCombustible(int id)
        {
            var combustible = await _context.Combustibles.FindAsync(id);

            if (combustible == null)
            {
                return NotFound();
            }

            return combustible;
        }

        // PUT: api/Combustibles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCombustible(int id, Combustible combustible)
        {
            if (id != combustible.IdCombustible)
            {
                return BadRequest();
            }

            _context.Entry(combustible).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CombustibleExists(id))
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

        // POST: api/Combustibles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Combustible>> PostCombustible(Combustible combustible)
        {
            _context.Combustibles.Add(combustible);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CombustibleExists(combustible.IdCombustible))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCombustible", new { id = combustible.IdCombustible }, combustible);
        }

        // DELETE: api/Combustibles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCombustible(int id)
        {
            var combustible = await _context.Combustibles.FindAsync(id);
            if (combustible == null)
            {
                return NotFound();
            }

            _context.Combustibles.Remove(combustible);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CombustibleExists(int id)
        {
            return _context.Combustibles.Any(e => e.IdCombustible == id);
        }
    }
}
