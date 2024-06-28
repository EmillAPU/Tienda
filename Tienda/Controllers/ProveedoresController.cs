using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Tienda.Models;


namespace Tienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedoresController : ControllerBase
    {
        public readonly TiendaContext _dbcontext;

        public ProveedoresController(TiendaContext _context)
        {
            _dbcontext = _context;
        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            List<Proveedores> lista = new List<Proveedores>();

            try
            {
                lista = _dbcontext.Proveedores.ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = lista });

            }

        }


        [HttpGet]
        [Route("Obtener/{idProveedor:int}")]
        public IActionResult Obtener(int idProveedor)
        {
            Proveedores oProveedor = _dbcontext.Proveedores.Find(idProveedor);

            if (oProveedor == null)
            {
                return BadRequest("Proveedor no encontrado");
            }

            List<Proveedores> lista = new List<Proveedores>();

            try
            {
                lista = _dbcontext.Proveedores.ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = oProveedor });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = oProveedor });

            }

        }

        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] Proveedores proveedores)
        {
            try
            {
                _dbcontext.Proveedores.Add(proveedores);
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
        public IActionResult Editar([FromBody] Proveedores proveedores)
        {
            Proveedores oProveedor = _dbcontext.Proveedores.Find(proveedores.IdProveedor);

            if (oProveedor == null)
            {
                return BadRequest("Producto no encontrado");
            }

            try
            {
                oProveedor.Nombre = proveedores.Nombre is null ? proveedores.Nombre : proveedores.Nombre;
                oProveedor.Direccion = proveedores.Direccion is null ? proveedores.Direccion : proveedores.Direccion;
                oProveedor.Telefono = proveedores.Telefono is null ? proveedores.Telefono : proveedores.Telefono;

                _dbcontext.Proveedores.Update(oProveedor);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });

            }

        }

        [HttpDelete]
        [Route("Eliminar/{idProveedor:int}")]
        public IActionResult Eliminar(int idProveedor)
        {
            Proveedores oProveedor = _dbcontext.Proveedores.Find(idProveedor);

            if (oProveedor == null)
            {
                return BadRequest("Proveedor no encontrado");
            }

            try
            {
                _dbcontext.Proveedores.Remove(oProveedor);
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


