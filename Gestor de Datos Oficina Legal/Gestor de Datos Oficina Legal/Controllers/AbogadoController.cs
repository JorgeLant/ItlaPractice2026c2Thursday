using Gestor_de_Datos_Oficina_Legal.Contexts;
using Gestor_de_Datos_Oficina_Legal.Models.DTOs;
using Gestor_de_Datos_Oficina_Legal.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gestor_de_Datos_Oficina_Legal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AbogadoController : ControllerBase
    {
        private readonly ConexionDB _context;

        public AbogadoController(ConexionDB context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Get-Abogados")]
        public async Task<ActionResult<IEnumerable<Abogado>>> GetAbogado(ConexionDB context)
        {
            var abogados = await _context.Abogados.AsNoTracking().ToListAsync();
            return Ok(abogados);
        }

        [HttpGet]
        [Route("GetId-Abogado")]
        public ActionResult<Abogado> GetByIdAbogado(int id)
        {
            var abogado =  _context.Abogados.FirstOrDefault(x => x.Id == id);
            if (abogado == null)
            {
                return NotFound();
            }
            return Ok(abogado);
        }

        [HttpPost]
        [Route("Post-Abogado")]
        public async Task<ActionResult<Abogado>> CreateAbogado(AbogadoDTO request)
        {
            var abogado = new Abogado
            {

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

            _context.Abogados.Add(abogado);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetByIdAbogado), new { id = abogado.Id }, abogado);
        }

        [HttpPut]
        [Route("PutID-Abogado")]
        public async Task<ActionResult> Update(int id, Abogado updatedAbogado)
        {
            var abogado =  _context.Abogados.FirstOrDefault(x => x.Id == id);
            if (abogado == null)
            {
                return NotFound();
            }
            abogado.CorreoElectronico = updatedAbogado.CorreoElectronico;
            abogado.NumeroTelefonico = updatedAbogado.NumeroTelefonico;
            abogado.Direccion = updatedAbogado.Direccion;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete]
        [Route("Delete-Abogado")]

        public async Task<ActionResult> DeleteAb(int id)
        {
            var abogado = _context.Abogados.FirstOrDefault(x => x.Id == id);
            if (abogado == null)
            {
                return NotFound();
            }
            _context.Abogados.Remove(abogado);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
