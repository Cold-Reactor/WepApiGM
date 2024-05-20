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
    public class TarifasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TarifasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Tarifas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tarifa>>> GetTarifas()
        {
            return await _context.Tarifa.ToListAsync();
        }

        // GET: api/Tarifas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tarifa>> GetTarifa(int id)
        {
            var tarifa = await _context.Tarifa.FindAsync(id);

            if (tarifa == null)
            {
                return NotFound();
            }

            return tarifa;
        }

        [HttpGet("Caseta/{idCaseta}")]
        public async Task<ActionResult<RequestTarifasTransporte>> GetTarifaTransporte(int idCaseta)
        {
            var RequestTarifasTransporte = new RequestTarifasTransporte();
            //var caseta = await _context.Tarifa.FirstOrDefaultAsync(x => x.IdCaseta == idCaseta);
            List<RequestTransportePrecio> transportTarifa = await ( from c in _context.Tarifa
                                                                    where c.IdCaseta == idCaseta
                                                                    select new RequestTransportePrecio 
                                                                    {
                                                                        IdTransporte= c.IdTransporte,
                                                                        Precio= c.Precio
                                                                    }
                                                                   ).ToListAsync();
            transportTarifa = transportTarifa.OrderBy(x => x.IdTransporte).ToList();

            if (transportTarifa == null)
            {
                return NotFound();
            }
            RequestTarifasTransporte.IdCaseta = idCaseta;
            RequestTarifasTransporte.TransporteTarifa = transportTarifa;


            return RequestTarifasTransporte;
        }
        // PUT: api/Tarifas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTarifa(int id, Tarifa tarifa)
        {
            if (id != tarifa.IdTarifa)
            {
                return BadRequest();
            }

            _context.Entry(tarifa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TarifaExists(id))
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

        // POST: api/Tarifas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tarifa>> PostTarifa(Tarifa tarifa)
        {
            _context.Tarifa.Add(tarifa);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TarifaExists(tarifa.IdTarifa))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTarifa", new { id = tarifa.IdTarifa }, tarifa);
        }

        // DELETE: api/Tarifas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTarifa(int id)
        {
            var tarifa = await _context.Tarifa.FindAsync(id);
            if (tarifa == null)
            {
                return NotFound();
            }

            _context.Tarifa.Remove(tarifa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TarifaExists(int id)
        {
            return _context.Tarifa.Any(e => e.IdTarifa == id);
        }
    }
}
