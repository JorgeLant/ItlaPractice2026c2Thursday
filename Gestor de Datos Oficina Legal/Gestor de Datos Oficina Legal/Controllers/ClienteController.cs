using Gestor_de_Datos_Oficina_Legal.Contexts;
using Gestor_de_Datos_Oficina_Legal.Models.DTOs;
using Gestor_de_Datos_Oficina_Legal.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gestor_de_Datos_Oficina_Legal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ConexionDB _context;

        public ClienteController(ConexionDB context)
        {
            
            _context = context;
        }

        [HttpGet]
        [Route("Get-Clientes")]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetCliente()
        {
            var cliente = await _context.Clientes.AsNoTracking().ToListAsync();
            return Ok(_context.Clientes);
        }

        [HttpGet]
        [Route("GetId-Clientes")]
        public ActionResult<Cliente> GetByIdCliente(int id)
        {
            var cliente = _context.Clientes.FirstOrDefault(x => x.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        [HttpPost]
        [Route("Post-Clientes")]
        public async Task<ActionResult<Cliente>> CreateCliente(ClienteDTO request)
        {
            var cliente = new Cliente()
            {

                Nombre = request.Nombre,
                Cedula = request.Cedula,
                NumeroTelefonico= request.NumeroTelefonico,
                CorreoElectronico= request.CorreoElectronico,
                Direccion= request.Direccion,
                TipoCliente= request.TipoCliente,
                FechaRegistro= request.FechaRegistro,
                Estado = request.Estado
            };

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetByIdCliente), new { id = cliente.Id }, cliente);
        }

        [HttpPut]
        [Route("PutId-Clientes")]
        public async Task<ActionResult> Update(int id, Cliente updatedCliente)
        {
            var cliente = _context.Clientes.FirstOrDefault(x => x.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }
            cliente.CorreoElectronico = updatedCliente.CorreoElectronico;
            cliente.NumeroTelefonico = updatedCliente.NumeroTelefonico;
            cliente.Direccion = updatedCliente.Direccion;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete]
        [Route("Delete-Clientes")]
        public async Task<ActionResult> Delete(int id)
        {
            var cliente = _context.Clientes.FirstOrDefault(x => x.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
