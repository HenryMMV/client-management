using Domain.Entities;

namespace Application.Interfaces;

public interface IClienteReadService
{
    Task<IReadOnlyList<Cliente>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Cliente?> GetByRucAsync(string ruc, CancellationToken cancellationToken = default);
}