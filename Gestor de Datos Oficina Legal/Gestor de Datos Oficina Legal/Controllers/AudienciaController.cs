using Gestor_de_Datos_Oficina_Legal.Contexts;
using Gestor_de_Datos_Oficina_Legal.Models.DTOs;
using Gestor_de_Datos_Oficina_Legal.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gestor_de_Datos_Oficina_Legal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AudienciaController: ControllerBase
    {
        private readonly ConexionDB _context;

        public AudienciaController(ConexionDB context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Get-Audiencias")]
        public async Task<ActionResult<IEnumerable<Audiencia>>> GetAudiencia()
        {
            var audiencia = await _context.Audiencias.AsNoTracking().ToListAsync();
            return Ok(_context.Audiencias);
        }

        [HttpGet]
        [Route("GetID-Audiencia")]
        public ActionResult<Audiencia> GetByIdAudiencia(int id)
        {
            var audiencia = _context.Audiencias.FirstOrDefault(x => x.Id == id);
            if (audiencia == null)
            {
                return NotFound();
            }
            return Ok(audiencia);
        }

        [HttpPost]
        [Route("Post-Audiencia")]
        public async Task<ActionResult<Audiencia>> CreateAudiencia(AudienciaDTO request)
        {
            var audiencia = new Audiencia
            {
                CasoAsociado=request.CasoAsociado,
                Fecha = request.Fecha,
                Hora = request.Hora,
                Tribunal=request.Tribunal,
                Estado = request.Estado,
            };

            _context.Audiencias.Add(audiencia);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetByIdAudiencia), new { id = audiencia.Id }, audiencia);
        }

        [HttpPut]
        [Route("Put-Audiencia")]
        public async Task<ActionResult> Update(int id, Audiencia updatedAudiencia)
        {
            var audiencia = _context.Audiencias.FirstOrDefault(x => x.Id == id);
            if (audiencia == null)
            {
                return NotFound();
            }
            audiencia.Estado = updatedAudiencia.Estado;
            audiencia.Fecha = updatedAudiencia.Fecha;
            audiencia.Hora = updatedAudiencia.Hora;
            audiencia.Tribunal = updatedAudiencia.Tribunal;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete]
        [Route("Delete-Audiencia")]
        public async Task<ActionResult> DeleteAu(int id)
        {
            var audiencia = _context.Audiencias.FirstOrDefault(x => x.Id == id);
            if (audiencia == null)
            {
                return NotFound();
            }
            _context.Audiencias.Remove(audiencia);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
