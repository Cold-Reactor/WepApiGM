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
    public class Viaje_rutaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public Viaje_rutaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Viaje_ruta
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Viaje_ruta>>> GetViajeRuta()
        {
            return await _context.ViajeRuta.ToListAsync();
        }

        // GET: api/Viaje_ruta/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Viaje_ruta>> GetViaje_ruta(int id)
        {
            var viaje_ruta = await _context.ViajeRuta.FindAsync(id);

            if (viaje_ruta == null)
            {
                return NotFound();
            }

            return viaje_ruta;
        }

        // PUT: api/Viaje_ruta/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutViaje_ruta(int id, Viaje_ruta viaje_ruta)
        {
            if (id != viaje_ruta.IdViajeRuta)
            {
                return BadRequest();
            }

            _context.Entry(viaje_ruta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Viaje_rutaExists(id))
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

        // POST: api/Viaje_ruta
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Viaje_ruta>> PostViaje_ruta(Viaje_ruta viaje_ruta)
        {
            _context.ViajeRuta.Add(viaje_ruta);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Viaje_rutaExists(viaje_ruta.IdViajeRuta))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetViaje_ruta", new { id = viaje_ruta.IdViajeRuta }, viaje_ruta);
        }

        // DELETE: api/Viaje_ruta/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteViaje_ruta(int id)
        {
            var viaje_ruta = await _context.ViajeRuta.FindAsync(id);
            if (viaje_ruta == null)
            {
                return NotFound();
            }

            _context.ViajeRuta.Remove(viaje_ruta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Viaje_rutaExists(int id)
        {
            return _context.ViajeRuta.Any(e => e.IdViajeRuta == id);
        }
    }
}
