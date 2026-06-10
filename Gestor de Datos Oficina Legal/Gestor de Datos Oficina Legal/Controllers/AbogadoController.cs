using Gestor_de_Datos_Oficina_Legal.Models.DTOs;
using Gestor_de_Datos_Oficina_Legal.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Gestor_de_Datos_Oficina_Legal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AbogadoController : ControllerBase
    {
        private static readonly List<Abogado> abogados = new List<Abogado>
        {
            new Abogado {Id = 1, Nombre = "Darling Quezada", Cedula = "402,0000001-1", Exequatur = "EXE-2020-001", NumeroTelefonico = "809-000-0001", CorreoElectronico = "Darlingquezada@gmail.com", Direccion = "Av.Charles de gaulle, Santo Domingo Este", Especialidad = "Laboral", FechaRegistro = new DateTime(2019,12,01), Estado = "Inactivo"},
            new Abogado {Id = 2, Nombre = "Wascar Mendieta", Cedula = "402,0000002-1", Exequatur = "EXE-2018-002", NumeroTelefonico = "829-000-0001", CorreoElectronico = "Wascarmendieta@gmail.com", Direccion = "Av.Monumental, Santo Domingo Este", Especialidad = "Penal", FechaRegistro = new DateTime(2014,12,01), Estado = "Activo"},
            new Abogado {Id = 3, Nombre = "Mariana Gonzalez", Cedula = "402,0000002-1", Exequatur = "EXE-2021-003", NumeroTelefonico = "849-000-0001", CorreoElectronico = "Marianagonzalez@gmail.com", Direccion = "Av.Winston Churchill, Distrito Nacional, Santo Domingo ", Especialidad = "Civil", FechaRegistro = new DateTime(2021,04,21), Estado = "Activo"}
        };

        [HttpGet]
        [Route("Get-Abogados")]
        public ActionResult<IEnumerable<Abogado>> GetAbogado()
        {
            return Ok(abogados);
        }

        [HttpGet]
        [Route("GetId-Abogado")]
        public ActionResult<Abogado> GetByIdAbogado(int id)
        {
            var abogado = abogados.FirstOrDefault(x => x.Id == id);
            if (abogado == null)
            {
                return NotFound();
            }
            return Ok(abogado);
        }

        [HttpPost]
        [Route("Post-Abogado")]
        public ActionResult<Abogado> CreateAbogado(AbogadoDTO request)
        {
            var abogado = new Abogado
            {
                Id = request.Id,
                Nombre = request.Nombre,
                Cedula = request.Cedula,
                Exequatur = request.Exequatur,
                NumeroTelefonico = request.NumeroTelefonico,
                CorreoElectronico = request.CorreoElectronico,
                Direccion = request.Direccion,
                Especialidad = request.Especialidad,
                FechaRegistro = request.FechaRegistro,
                Estado = request.Estado,
            };
            abogado.Id = abogados.Max(x => x.Id) + 1;
            abogados.Add(abogado);
            return CreatedAtAction(nameof(GetByIdAbogado), new { id = abogado.Id }, abogado);
        }

        [HttpPut]
        [Route("PutID-Abogado")]
        public ActionResult Update(int id, Abogado updatedAbogado)
        {
            var abogado = abogados.FirstOrDefault(x => x.Id == id);
            if (abogado == null)
            {
                return NotFound();
            }
            abogado.CorreoElectronico = updatedAbogado.CorreoElectronico;
            abogado.NumeroTelefonico = updatedAbogado.NumeroTelefonico;
            abogado.Direccion = updatedAbogado.Direccion;
            return NoContent();
        }

        [HttpDelete]
        [Route("Delete-Abogado")]

        public ActionResult DeleteAb(int id)
        {
            var abogado = abogados.FirstOrDefault(x => x.Id == id);
            if (abogado == null)
            {
                return NotFound();
            }
            abogados.Remove(abogado);
            return NoContent();
        }
    }
}
