using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


using Microsoft.EntityFrameworkCore;
using Tienda.Models;


namespace Tienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        public readonly TiendaContext _dbcontext;

        public CategoriaController(TiendaContext _context)
        {
            _dbcontext = _context;
        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista() 
        {
            List<Categoria> lista = new List<Categoria>();

            try
            {
                lista = _dbcontext.Categorias.ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });
            }
            catch (Exception ex) {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = lista });

            }

        }


        [HttpGet]
        [Route("Obtener/{idCategoria:int}")]
        public IActionResult Obtener(int idCategoria)
        {
            Categoria oCategoria = _dbcontext.Categorias.Find(idCategoria);

            if (oCategoria == null)
            {
                return BadRequest("Categoria no encontrada");
            }

            try
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = oCategoria });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = oCategoria });

            }

        }

        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] Categoria categoria)
        {
            try
            {
                _dbcontext.Categorias.Add(categoria);
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
        public IActionResult Editar([FromBody] Categoria categoria)
        {
            Categoria oCategoria = _dbcontext.Categorias.Find(categoria.IdCategoria);

            if (oCategoria == null)
            {
                return BadRequest("Categoria no encontrada");
            }

            try
            {
                oCategoria.Descripcion = categoria.Descripcion is null ? oCategoria.Descripcion : categoria.Descripcion;  

                _dbcontext.Categorias.Update(oCategoria);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });

            }

        }

        [HttpDelete]
        [Route("Eliminar/{idCategoria:int}")]
        public IActionResult Eliminar(int idCategoria)
        {
            Categoria oCategoria = _dbcontext.Categorias.Find(idCategoria);

            if (oCategoria == null)
            {
                return BadRequest("Categoria no encontrada");
            }

            try
            {
                _dbcontext.Categorias.Remove(oCategoria);
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

            
        
    
