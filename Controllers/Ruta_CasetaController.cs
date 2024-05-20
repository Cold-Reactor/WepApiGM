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
    public class Ruta_CasetaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public Ruta_CasetaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Ruta_Caseta
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ruta_caseta>>> GetRutaCaseta()
        {
            return await _context.RutaCaseta.ToListAsync();
        }

        // GET: api/Ruta_Caseta/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ruta_caseta>> GetRuta_Caseta(int id)
        {
            var ruta_Caseta = await _context.RutaCaseta.FindAsync(id);

            if (ruta_Caseta == null)
            {
                return NotFound();
            }

            return ruta_Caseta;
        }

        // PUT: api/Ruta_Caseta/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRuta_Caseta(int id, Ruta_caseta ruta_Caseta)
        {
            if (id != ruta_Caseta.IdRutaCaseta)
            {
                return BadRequest();
            }

            _context.Entry(ruta_Caseta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Ruta_CasetaExists(id))
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

        // POST: api/Ruta_Caseta
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ruta_caseta>> PostRuta_Caseta(Ruta_caseta ruta_Caseta)
        {
            _context.RutaCaseta.Add(ruta_Caseta);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Ruta_CasetaExists(ruta_Caseta.IdRutaCaseta))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRuta_Caseta", new { id = ruta_Caseta.IdRutaCaseta }, ruta_Caseta);
        }

        // DELETE: api/Ruta_Caseta/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRuta_Caseta(int id)
        {
            var ruta_Caseta = await _context.RutaCaseta.FindAsync(id);
            if (ruta_Caseta == null)
            {
                return NotFound();
            }

            _context.RutaCaseta.Remove(ruta_Caseta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Ruta_CasetaExists(int id)
        {
            return _context.RutaCaseta.Any(e => e.IdRutaCaseta == id);
        }
    }
}
