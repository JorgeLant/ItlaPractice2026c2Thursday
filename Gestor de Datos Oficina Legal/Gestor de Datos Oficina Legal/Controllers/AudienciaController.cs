using Gestor_de_Datos_Oficina_Legal.Models.DTOs;
using Gestor_de_Datos_Oficina_Legal.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Gestor_de_Datos_Oficina_Legal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AudienciaController: ControllerBase
    {
        private static readonly List<Audiencia> audiencias = new List<Audiencia>
        {
            new Audiencia {Id = 1, CasoAsociado = 3, Fecha = new DateTime(2026,08,14), Hora = new TimeOnly(16,30), Tribunal = "Palacio de Justicia de la Provincia Santo Domingo", Estado = "Activo"},
            new Audiencia {Id = 2, CasoAsociado = 1, Fecha = new DateTime(2024,05,30), Hora = new TimeOnly(10,00), Tribunal = "Edificio Suprema Corte de Justicia", Estado = "Cerrado"},
            new Audiencia {Id = 3, CasoAsociado = 2, Fecha = new DateTime(2025,11,02), Hora = new TimeOnly(00,00), Tribunal = "Palacio de justicia de Santiago", Estado = "Suspendido"}
        };

        [HttpGet]
        [Route("Get-Audiencias")]
        public ActionResult<IEnumerable<Audiencia>> GetAudiencia()
        {
            return Ok(audiencias);
        }

        [HttpGet]
        [Route("GetID-Audiencia")]
        public ActionResult<Audiencia> GetByIdAudiencia(int id)
        {
            var audiencia = audiencias.FirstOrDefault(x => x.Id == id);
            if (audiencia == null)
            {
                return NotFound();
            }
            return Ok(audiencia);
        }

        [HttpPost]
        [Route("Post-Audiencia")]
        public ActionResult<Audiencia> CreateAudiencia(AudienciaDTO request)
        {
            var audiencia = new Audiencia
            {
                Id = request.Id,
                CasoAsociado=request.CasoAsociado,
                Fecha = request.Fecha,
                Hora = request.Hora,
                Tribunal=request.Tribunal,
                Estado = request.Estado,
            };
            audiencia.Id = audiencias.Max(x => x.Id) + 1;
            audiencias.Add(audiencia);
            return CreatedAtAction(nameof(GetByIdAudiencia), new { id = audiencia.Id }, audiencia);
        }

        [HttpPut]
        [Route("Put-Audiencia")]
        public ActionResult Update(int id, Audiencia updatedAudiencia)
        {
            var audiencia = audiencias.FirstOrDefault(x => x.Id == id);
            if (audiencia == null)
            {
                return NotFound();
            }
            audiencia.Estado = updatedAudiencia.Estado;
            audiencia.Fecha = updatedAudiencia.Fecha;
            audiencia.Hora = updatedAudiencia.Hora;
            audiencia.Tribunal = updatedAudiencia.Tribunal;
            return NoContent();
        }

        [HttpDelete]
        [Route("Delete-Audiencia")]
        public ActionResult DeleteAu(int id)
        {
            var audiencia = audiencias.FirstOrDefault(x => x.Id == id);
            if (audiencia == null)
            {
                return NotFound();
            }
            audiencias.Remove(audiencia);
            return NoContent();
        }
    }
}
