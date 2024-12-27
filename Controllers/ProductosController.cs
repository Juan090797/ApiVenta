using ApiVenta.Data;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Get()
        {
            return Ok(_context.Producto);
        }

    }
}
