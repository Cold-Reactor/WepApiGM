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
    public class CasetasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CasetasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Casetas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Caseta>>> GetCaseta()
        {
            return await _context.Caseta.ToListAsync();
        }

        // GET: api/Casetas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Caseta>> GetCaseta(int id)
        {
            var caseta = await _context.Caseta.FindAsync(id);

            if (caseta == null)
            {
                return NotFound();
            }

            return caseta;
        }

        // PUT: api/Casetas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCaseta(int id, Caseta caseta)
        {
            if (id != caseta.IdCaseta)
            {
                return BadRequest();
            }

            _context.Entry(caseta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CasetaExists(id))
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

        // POST: api/Casetas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Caseta>> PostCaseta(Caseta caseta)
        {
            _context.Caseta.Add(caseta);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CasetaExists(caseta.IdCaseta))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCaseta", new { id = caseta.IdCaseta }, caseta);
        }

        // DELETE: api/Casetas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCaseta(int id)
        {
            var caseta = await _context.Caseta.FindAsync(id);
            if (caseta == null)
            {
                return NotFound();
            }

            _context.Caseta.Remove(caseta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CasetaExists(int id)
        {
            return _context.Caseta.Any(e => e.IdCaseta == id);
        }
    }
}
