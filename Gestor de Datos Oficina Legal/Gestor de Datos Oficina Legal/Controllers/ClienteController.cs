using Gestor_de_Datos_Oficina_Legal.Models.DTOs;
using Gestor_de_Datos_Oficina_Legal.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Gestor_de_Datos_Oficina_Legal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private static readonly List<Cliente> clientes = new List<Cliente>()
        {
            new Cliente {Id = 1, Nombre = "Adrian Rojas", Cedula = "001-0000001-1",NumeroTelefonico = "809-000-0001", CorreoElectronico = "Adrianrojas@gmail.com", Direccion = "Av. Monumental, Distrito Nacional, Santo Domingo",TipoCliente = "Persona fisica", FechaRegistro = new DateTime(2025,08,14), Estado = "Activo"},
            new Cliente {Id = 2, Nombre = "Axel Vasquez", Cedula = "001-0000002-1",NumeroTelefonico = "829-000-0001", CorreoElectronico = "Axelvasquez@gmail.com", Direccion = "Los Alcarrizos, Santo Domingo",TipoCliente = "Persona fisica", FechaRegistro = new DateTime(2020,03,28), Estado = "Inactivo"},
            new Cliente {Id = 3, Nombre = "Carlos Fernandez", Cedula = "001-0000003-1",NumeroTelefonico = "849-000-0001", CorreoElectronico = "Carlosfernandez@gmail.com", Direccion = "Av. Republica de Colombia, Distrito Nacional, Santo Domingo",TipoCliente = "Persona fisica", FechaRegistro = new DateTime(2018,10,04), Estado = "Activo"}
        };

        [HttpGet]
        [Route("Get-Clientes")]
        public ActionResult<IEnumerable<Cliente>> GetCliente()
        {
            return Ok(clientes);
        }

        [HttpGet]
        [Route("GetId-Clientes")]
        public ActionResult<Cliente> GetByIdCliente(int id)
        {
            var cliente = clientes.FirstOrDefault(x => x.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        [HttpPost]
        [Route("Post-Clientes")]
        public ActionResult<Cliente> CreateCliente(ClienteDTO request)
        {
            var cliente = new Cliente()
            {
                Id = request.Id,
                Nombre = request.Nombre,
                Cedula = request.Cedula,
                NumeroTelefonico= request.NumeroTelefonico,
                CorreoElectronico= request.CorreoElectronico,
                Direccion= request.Direccion,
                TipoCliente= request.TipoCliente,
                FechaRegistro= request.FechaRegistro,
                Estado = request.Estado
            };
            cliente.Id = clientes.Max(x => x.Id) + 1;
            clientes.Add(cliente);
            return CreatedAtAction(nameof(GetByIdCliente), new { id = cliente.Id }, cliente);
        }

        [HttpPut]
        [Route("PutId-Clientes")]
        public ActionResult Update(int id, Cliente updatedCliente)
        {
            var cliente = clientes.FirstOrDefault(x => x.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }
            cliente.CorreoElectronico = updatedCliente.CorreoElectronico;
            cliente.NumeroTelefonico = updatedCliente.NumeroTelefonico;
            cliente.Direccion = updatedCliente.Direccion;
            return NoContent();
        }

        [HttpDelete]
        [Route("Delete-Clientes")]
        public ActionResult Delete(int id)
        {
            var cliente = clientes.FirstOrDefault(x => x.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }
            clientes.Remove(cliente);
            return NoContent();
        }
    }
}
