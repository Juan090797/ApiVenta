using ApiVenta.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiVenta.Controllers
{
    [Route("api/v1/ventas")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VentasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/v1/ventas
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var ventas = await _context.Venta
                                .Include(v => v.VentaDetalles)
                                .ThenInclude(d => d.Producto)
                                .ToListAsync();
        
            return Ok(ventas);
        }
    }
}
