using BibliotecaClases.Core.Interfaces;
using BibliotecaClases.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaClases.Infrastructure.Repositories
{
    public class OrdenServicioRepository : IOrdenServicioRepository
    {
        private readonly TallerDbContext _context;

        public OrdenServicioRepository(TallerDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OrdenServicio>> GetOrdenesAsync()
        {
            return await _context.OrdenServicios.ToListAsync();
        }

        public async Task<OrdenServicio?> GetOrdenByIdAsync(int id)
        {
            return await _context.OrdenServicios.FindAsync(id);
        }

        public async Task AddOrdenAsync(OrdenServicio orden)
        {
            await _context.OrdenServicios.AddAsync(orden);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOrdenAsync(OrdenServicio orden)
        {
            _context.Entry(orden).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrdenAsync(int id)
        {
            var orden = await _context.OrdenServicios.FindAsync(id);
            if (orden != null)
            {
                _context.OrdenServicios.Remove(orden);
                await _context.SaveChangesAsync();
            }
        }
    }
}