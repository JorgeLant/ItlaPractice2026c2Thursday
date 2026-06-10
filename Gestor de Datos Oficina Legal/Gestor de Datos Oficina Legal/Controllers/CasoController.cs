using Gestor_de_Datos_Oficina_Legal.Models.DTOs;
using Gestor_de_Datos_Oficina_Legal.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Gestor_de_Datos_Oficina_Legal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CasoController: ControllerBase
    {
        private static readonly List<Caso> casos = new List<Caso>
        {
            new Caso {Id = 1, NumeroExpediente = "001-0001", ClienteAsociado = 2, AbogadoAsociado = 3, Titulo = "Demanda por incumplimiento de contrato", TipoCaso = "Civil", Descripcion = "El presunto caballero....", FechaApertura = new DateTime(2021,06,09), Tribunal = "Edificio Suprema Corte de Justicia", ParteContraria = "No definida", Estado = "Suspendido"},
            new Caso {Id = 2, NumeroExpediente = "001-0002", ClienteAsociado = 3, AbogadoAsociado = 1, Titulo = "Reclamación por despido injustificado", TipoCaso = "Laboral", Descripcion = "El presunto caballero....", FechaApertura = new DateTime(2023,06,09), Tribunal = "Palacio de justicia de Santiago", ParteContraria = "No definida", Estado = "Cerrado"},
            new Caso {Id = 3, NumeroExpediente = "001-0003", ClienteAsociado = 1, AbogadoAsociado = 2, Titulo = "Querella por robo agravado", TipoCaso = "Penal", Descripcion = "El presunto caballero....", FechaApertura = new DateTime(2024,09,11), Tribunal = "Palacio de Justicia de la Provincia Santo Domingo", ParteContraria = "No definida", Estado = "Activo"}
        };

        [HttpGet]
        [Route("Get-Casos")]
        public ActionResult<IEnumerable<Caso>> GetCaso()
        {
            return Ok(casos);
        }

        [HttpGet]
        [Route("GetID-Caso")]

        public ActionResult<Caso> GetByIdCaso(int id)
        {
            var caso = casos.FirstOrDefault(x => x.Id == id);
            if (caso == null)
            {
                return NotFound();
            }
            return Ok(caso);
        }

        [HttpPost]
        [Route("Post-Casos")]
        public ActionResult<Caso> CreateCaso(CasoDTO request)
        {
            var caso = new Caso
            {
                Id = request.Id,
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
            caso.Id = casos.Max(x => x.Id) + 1;
            casos.Add(caso);
            return CreatedAtAction(nameof(GetByIdCaso), new { id = caso.Id }, caso);
        }

        [HttpPut]
        [Route("PutID-Caso")]

        public ActionResult Update(int id, Caso updatedCaso)
        {
            var caso = casos.FirstOrDefault(x => x.Id == id);
            if (caso == null)
            {
                return NotFound();
            }

            caso.Estado = updatedCaso.Estado;
            caso.FechaApertura = updatedCaso.FechaApertura;
            caso.Tribunal = updatedCaso.Tribunal;
            return NoContent();
        }

        [HttpDelete]
        [Route("Delete-Caso")]

        public ActionResult DeleteC(int id)
        {
            var caso = casos.FirstOrDefault(x => x.Id == id);
            if (caso == null)
            {
                return NotFound();
            }
            casos.Remove(caso);
            return NoContent();
        }
    }
}
