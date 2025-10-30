using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class ClienteReadService(ClientDbContext db) : IClienteReadService
{
    public async Task<IReadOnlyList<Cliente>> GetAllAsync(CancellationToken cancellationToken = default)
        => await db.Clientes.AsNoTracking().ToListAsync(cancellationToken);

    public async Task<Cliente?> GetByRucAsync(string ruc, CancellationToken cancellationToken = default)
        => await db.Clientes.AsNoTracking().FirstOrDefaultAsync(x => x.Ruc == ruc, cancellationToken);
}