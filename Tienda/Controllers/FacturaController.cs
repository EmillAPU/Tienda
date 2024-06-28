using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Tienda.Models;


namespace Tienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        public readonly TiendaContext _dbcontext;

        public FacturaController(TiendaContext _context)
        {
            _dbcontext = _context;
        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            List<Factura> lista = new List<Factura>();

            try
            {
                lista = _dbcontext.Facturas.Include(c => c.oCliente).ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = lista });

            }

        }


        [HttpGet]
        [Route("Obtener/{idFactura:int}")]
        public IActionResult Obtener(int idFactura)
        {
            Factura oFactura = _dbcontext.Facturas.Find(idFactura);

            if (oFactura == null)
            {
                return BadRequest("Factura no encontrada");
            }

            List<Factura> lista = new List<Factura>();

            try
            {
                lista = _dbcontext.Facturas.Include(c => c.oCliente).ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = oFactura });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = oFactura });

            }

        }

        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] Factura factura)
        {
            try
            {
                _dbcontext.Facturas.Add(factura);
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
        public IActionResult Editar([FromBody] Factura factura)
        {
            Factura oFactura = _dbcontext.Facturas.Find(factura.IdFactura);

            if (oFactura == null)
            {
                return BadRequest("Factura no encontrada");
            }

            try
            {
                oFactura.Fecha = factura.Fecha is null ? factura.Fecha : factura.Fecha;

                _dbcontext.Facturas.Update(oFactura);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });

            }

        }

        [HttpDelete]
        [Route("Eliminar/{idFactura:int}")]
        public IActionResult Eliminar(int idFactura)
        {
            Factura oFactura = _dbcontext.Facturas.Find(idFactura);

            if (oFactura == null)
            {
                return BadRequest("Factura no encontrada");
            }

            try
            {
                _dbcontext.Facturas.Remove(oFactura);
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


