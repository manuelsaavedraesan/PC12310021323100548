using BibliotecaClases.Infrastructure.Data;

namespace BibliotecaClases.Core.Interfaces
{
    public interface IOrdenServicioRepository
    {
        Task<IEnumerable<OrdenServicio>> GetOrdenesAsync();
        Task<OrdenServicio?> GetOrdenByIdAsync(int id);
        Task AddOrdenAsync(OrdenServicio orden);
        Task UpdateOrdenAsync(OrdenServicio orden);
        Task DeleteOrdenAsync(int id);
    }
}