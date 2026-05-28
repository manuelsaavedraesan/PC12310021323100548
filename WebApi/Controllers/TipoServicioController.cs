using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BibliotecaClases.Infrastructure.Data;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController] // Atributo solicitado en el examen
    public class TipoServicioController : ControllerBase
    {
        private readonly TallerDbContext _context;

        // Inyección directa del DbContext (Sin repository)
        public TipoServicioController(TallerDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var servicios = await _context.TipoServicios.ToListAsync();
            return Ok(servicios);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TipoServicio tipoServicio)
        {
            _context.TipoServicios.Add(tipoServicio);
            await _context.SaveChangesAsync();
            return Ok(tipoServicio);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TipoServicio tipoServicio)
        {
            if (id != tipoServicio.Id) return BadRequest("El ID proporcionado no coincide.");

            _context.Entry(tipoServicio).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var servicio = await _context.TipoServicios.FindAsync(id);
            if (servicio == null) return NotFound();

            _context.TipoServicios.Remove(servicio);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}