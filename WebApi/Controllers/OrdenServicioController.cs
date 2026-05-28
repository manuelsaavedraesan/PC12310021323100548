using Microsoft.AspNetCore.Mvc;
using BibliotecaClases.Core.Interfaces;
using BibliotecaClases.Infrastructure.Data;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenServicioController : ControllerBase
    {
        private readonly IOrdenServicioRepository _repository;

        // Aquí inyectamos la Interfaz, cumpliendo el patrón Repository
        public OrdenServicioController(IOrdenServicioRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var ordenes = await _repository.GetOrdenesAsync();
            return Ok(ordenes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var orden = await _repository.GetOrdenByIdAsync(id);
            if (orden == null) return NotFound();
            return Ok(orden);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrdenServicio orden)
        {
            await _repository.AddOrdenAsync(orden);
            return Ok(orden);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] OrdenServicio orden)
        {
            if (id != orden.Id) return BadRequest("Los IDs no coinciden.");

            await _repository.UpdateOrdenAsync(orden);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteOrdenAsync(id);
            return NoContent();
        }
    }
}