using Gestor_de_Datos_Oficina_Legal.Contexts;
using Gestor_de_Datos_Oficina_Legal.Models.DTOs;
using Gestor_de_Datos_Oficina_Legal.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gestor_de_Datos_Oficina_Legal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CasoController: ControllerBase
    {
        private readonly ConexionDB _context;

        public CasoController(ConexionDB context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Get-Casos")]
        public async Task<ActionResult<IEnumerable<Caso>>> GetCaso()
        {
            var caso = await _context.Casos.AsNoTracking().ToListAsync();
            return Ok(_context.Casos);
        }

        [HttpGet]
        [Route("GetID-Caso")]

        public ActionResult<Caso> GetByIdCaso(int id)
        {
            var caso = _context.Casos.FirstOrDefault(x => x.Id == id);
            if (caso == null)
            {
                return NotFound();
            }
            return Ok(caso);
        }

        [HttpPost]
        [Route("Post-Casos")]
        public async Task<ActionResult<Caso>> CreateCaso(CasoDTO request)
        {
            var caso = new Caso
            {
                NumeroExpediente = request.NumeroExpediente,
                ClienteAsociado = request.ClienteAsociado,
                AbogadoAsociado = request.AbogadoAsociado,
                Titulo = request.Titulo,
                TipoCaso = request.TipoCaso,
                Descripcion = request.Descripcion,
                FechaApertura = request.FechaApertura,
                Tribunal = request.Tribunal,
                ParteContraria = request.ParteContraria,
                Estado = request.Estado
            };

            _context.Casos.Add(caso);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetByIdCaso), new { id = caso.Id }, caso);
        }

        [HttpPut]
        [Route("PutID-Caso")]

        public async Task<ActionResult> Update(int id, Caso updatedCaso)
        {
            var caso = _context.Casos.FirstOrDefault(x => x.Id == id);
            if (caso == null)
            {
                return NotFound();
            }

            caso.Estado = updatedCaso.Estado;
            caso.FechaApertura = updatedCaso.FechaApertura;
            caso.Tribunal = updatedCaso.Tribunal;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete]
        [Route("Delete-Caso")]

        public async Task<ActionResult> DeleteC(int id)
        {
            var caso = _context.Casos.FirstOrDefault(x => x.Id == id);
            if (caso == null)
            {
                return NotFound();
            }
            _context.Casos.Remove(caso);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
