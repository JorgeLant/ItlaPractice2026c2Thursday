using Gestor_de_Datos_Oficina_Legal.Controllers.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Gestor_de_Datos_Oficina_Legal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GestorDatosController : ControllerBase
    {
        private static readonly List<Cliente> clientes = new List<Cliente>()
        {
            new Cliente {Id = 1, Nombre = "Adrian Rojas", Cedula = "001-0000001-1",NumeroTelefonico = "809-000-0001", CorreoElectronico = "Adrianrojas@gmail.com", Direccion = "Av. Monumental, Distrito Nacional, Santo Domingo",TipoCliente = "Persona fisica", FechaRegistro = new DateTime(2025,08,14), Estado = "Activo"},
            new Cliente {Id = 2, Nombre = "Axel Vasquez", Cedula = "001-0000002-1",NumeroTelefonico = "829-000-0001", CorreoElectronico = "Axelvasquez@gmail.com", Direccion = "Los Alcarrizos, Santo Domingo",TipoCliente = "Persona fisica", FechaRegistro = new DateTime(2020,03,28), Estado = "Inactivo"},
            new Cliente {Id = 3, Nombre = "Carlos Fernandez", Cedula = "001-0000003-1",NumeroTelefonico = "849-000-0001", CorreoElectronico = "Carlosfernandez@gmail.com", Direccion = "Av. Republica de Colombia, Distrito Nacional, Santo Domingo",TipoCliente = "Persona fisica", FechaRegistro = new DateTime(2018,10,04), Estado = "Activo"}
        };

        private static readonly List<Abogado> abogados = new List<Abogado>
        {
            new Abogado {Id = 1, Nombre = "Darling Quezada", Cedula = "402,0000001-1", Exequatur = "EXE-2020-001", NumeroTelefonico = "809-000-0001", CorreoElectronico = "Darlingquezada@gmail.com", Direccion = "Av.Charles de gaulle, Santo Domingo Este", Especialidad = "Laboral", FechaRegistro = new DateTime(2019,12,01), Estado = "Inactivo"},
            new Abogado {Id = 2, Nombre = "Wascar Mendieta", Cedula = "402,0000002-1", Exequatur = "EXE-2018-002", NumeroTelefonico = "829-000-0001", CorreoElectronico = "Wascarmendieta@gmail.com", Direccion = "Av.Monumental, Santo Domingo Este", Especialidad = "Penal", FechaRegistro = new DateTime(2014,12,01), Estado = "Activo"},
            new Abogado {Id = 3, Nombre = "Mariana Gonzalez", Cedula = "402,0000002-1", Exequatur = "EXE-2021-003", NumeroTelefonico = "849-000-0001", CorreoElectronico = "Marianagonzalez@gmail.com", Direccion = "Av.Winston Churchill, Distrito Nacional, Santo Domingo ", Especialidad = "Civil", FechaRegistro = new DateTime(2021,04,21), Estado = "Activo"}
        };

        private static readonly List<Caso> casos = new List<Caso>
        {
            new Caso {Id = 1, NumeroExpediente = "001-0001", ClienteAsociado = 2, AbogadoAsociado = 3, Titulo = "Demanda por incumplimiento de contrato", TipoCaso = "Civil", Descripcion = "El presunto caballero....", FechaApertura = new DateTime(2021,06,09), Estado = "Suspendido", Tribunal = "Edificio Suprema Corte de Justicia", ParteContraria = "No definida"},
            new Caso {Id = 2, NumeroExpediente = "001-0002", ClienteAsociado = 3, AbogadoAsociado = 1, Titulo = "Reclamación por despido injustificado", TipoCaso = "Laboral", Descripcion = "El presunto caballero....", FechaApertura = new DateTime(2023,06,09), Estado = "Cerrado", Tribunal = "Palacio de justicia de Santiago", ParteContraria = "No definida"},
            new Caso {Id = 3, NumeroExpediente = "001-0003", ClienteAsociado = 1, AbogadoAsociado = 2, Titulo = "Querella por robo agravado", TipoCaso = "Penal", Descripcion = "El presunto caballero....", FechaApertura = new DateTime(2024,09,11), Estado = "Activo", Tribunal = "Palacio de Justicia de la Provincia Santo Domingo", ParteContraria = "No definida"}
        };
        private static readonly List<Audiencia> audiencias = new List<Audiencia>
        {
            new Audiencia {Id = 1, CasoAsociado = 3, Fecha = new DateTime(2026,08,14), Hora = new TimeOnly(16,30), Tribunal = "Palacio de Justicia de la Provincia Santo Domingo", Estado = "Activo"},
            new Audiencia {Id = 2, CasoAsociado = 1, Fecha = new DateTime(2024,05,30), Hora = new TimeOnly(10,00), Tribunal = "Edificio Suprema Corte de Justicia", Estado = "Cerrado"},
            new Audiencia {Id = 3, CasoAsociado = 2, Fecha = new DateTime(2025,11,02), Hora = new TimeOnly(00,00), Tribunal = "Palacio de justicia de Santiago", Estado = "Suspendido"}
        };

        //============================================
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
        public ActionResult<Cliente> CreateCliente(Cliente cliente)
        {
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

        //================================================
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
        public ActionResult<Abogado> CreateAbogado(Abogado abogado)
        {
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
        //============================================
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
        public ActionResult<Caso> CreateCaso(Caso caso)
        {
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
        //=======================================
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
        public ActionResult<Audiencia> CreateAudiencia(Audiencia audiencia)
        {
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
