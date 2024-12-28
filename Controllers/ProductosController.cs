using ApiVenta.Data;
using ApiVenta.DTOs;
using ApiVenta.Models;
using ApiVenta.Responses;
using Microsoft.AspNetCore.Mvc;


//DTO: USALO CUANDO NECESITAS TRANSFERIR DATOS ENTRE CAPAS DE TU APLICACIÓN (MODELO DE DOMINIO Y CONTROLADORES),
//SIMPLIFICAR O REDUCIR LA CANTIDAD DE DATOS QUE SE TRANSFIEREN ENTRE CAPAS DE TU APLICACIÓN
//DATARESPONSE: USALO CUANDO NECESITAS ESTANDARIZAR TODAS LAS RESPUESTAS DE TU API

namespace ApiVenta.Controllers
{
    [Route("api/v1/products")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        //constructor
        public ProductosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/v1/products
        [HttpGet]
        public ActionResult<DataResponse<List<ProductoDTO>>> GetProducts()
        {
            var productos = _context.Producto.ToList();

            var productosDTO = productos.Select(p => new ProductoDTO
            {
                Nombre = p.Nombre,
                Precio = p.Precio
            }).ToList();


            var resultado = new DataResponse<List<ProductoDTO>>
            {
                Data = productosDTO,
                Message = "Lista de productos",
                Success = true
            };

            return Ok(resultado);

        }

        // GET: api/v1/products/5
        [HttpGet("{id}", Name = "GetProducto")]
        public IActionResult Get(int id)
        {
            var producto = _context.Producto.Find(id);
            if (producto == null)
            {
                return NotFound();
            }
            return Ok(producto);
        }


        // POST: api/v1/products
        [HttpPost]
        public IActionResult Post([FromBody] Producto producto)
        {
            _context.Producto.Add(producto);
            _context.SaveChanges();
            return CreatedAtRoute("GetProducto", new { id = producto.Id }, producto);
        }

    }
}
