using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace servicio_empresa_abc;

public class WebClienteDbContext : DbContext
{
    public WebClienteDbContext(DbContextOptions<WebClienteDbContext> options)
        :base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}