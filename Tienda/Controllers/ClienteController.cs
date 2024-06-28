using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


using Microsoft.EntityFrameworkCore;
using Tienda.Models;


namespace Tienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        public readonly TiendaContext _dbcontext;

        public ClienteController(TiendaContext _context)
        {
            _dbcontext = _context;
        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            List<Cliente> lista = new List<Cliente>();

            try
            {
                lista = _dbcontext.Clientes.ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = lista });

            }

        }


        [HttpGet]
        [Route("Obtener/{idCliente:int}")]
        public IActionResult Obtener(int idCliente)
        {
            Cliente oCliente = _dbcontext.Clientes.Find(idCliente);

            if (oCliente == null)
            {
                return BadRequest("Cliente no encontrado");
            }

            try
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = oCliente });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = oCliente });

            }

        }

        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] Cliente cliente)
        {
            try
            {
                _dbcontext.Clientes.Add(cliente);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });

            }

        }

        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] Cliente cliente)
        {
            Cliente oCliente = _dbcontext.Clientes.Find(cliente.IdCliente);

            if (oCliente == null)
            {
                return BadRequest("Cliente no encontrado");
            }

            try
            {
                oCliente.Nombre = cliente.Nombre is null ? cliente.Nombre : cliente.Nombre;
                oCliente.Direccion = cliente.Direccion is null ? cliente.Direccion : cliente.Direccion;
                oCliente.Telefono = cliente.Telefono is null ? cliente.Telefono : cliente.Telefono;

                _dbcontext.Clientes.Update(oCliente);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });

            }

        }

        [HttpDelete]
        [Route("Eliminar/{idCliente:int}")]
        public IActionResult Eliminar(int idCliente)
        {
            Cliente oCliente = _dbcontext.Clientes.Find(idCliente);

            if (oCliente == null)
            {
                return BadRequest("Cliente no encontrado");
            }

            try
            {
                _dbcontext.Clientes.Remove(oCliente);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });

            }
        }


    }
}



