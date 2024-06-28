using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Tienda.Models;


namespace Tienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        public readonly TiendaContext _dbcontext;

        public VentaController(TiendaContext _context)
        {
            _dbcontext = _context;
        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            List<Venta> lista = new List<Venta>();

            try
            {
                lista = _dbcontext.Ventas.Include(c => c.oFactura).ToList();
                lista = _dbcontext.Ventas.Include(c => c.oProducto).ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = lista });

            }

        }


        [HttpGet]
        [Route("Obtener/{idVenta:int}")]
        public IActionResult Obtener(int idVenta)
        {
            Venta oVenta = _dbcontext.Ventas.Find(idVenta);

            if (oVenta == null)
            {
                return BadRequest("Venta no encontrada");
            }

            List<Venta> lista = new List<Venta>();

            try
            {
                lista = _dbcontext.Ventas.Include(c => c.oFactura).ToList();
                lista = _dbcontext.Ventas.Include(c => c.oProducto).ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = oVenta });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = oVenta });

            }

        }

        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] Venta venta)
        {
            try
            {
                _dbcontext.Ventas.Add(venta);
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
        public IActionResult Editar([FromBody] Venta venta)
        {
            Venta oVenta = _dbcontext.Ventas.Find(venta.IdVenta);

            if (oVenta == null)
            {
                return BadRequest("Venta no encontrada");
            }

            try
            {
                oVenta.Cantidad = venta.Cantidad is null ? venta.Cantidad : venta.Cantidad;

                _dbcontext.Ventas.Update(oVenta);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });

            }

        }

        [HttpDelete]
        [Route("Eliminar/{idVenta:int}")]
        public IActionResult Eliminar(int idVenta)
        {
            Venta oVenta = _dbcontext.Ventas.Find(idVenta);

            if (oVenta == null)
            {
                return BadRequest("Venta no encontrada");
            }

            try
            {
                _dbcontext.Ventas.Remove(oVenta);
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
