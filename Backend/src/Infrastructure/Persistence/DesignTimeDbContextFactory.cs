using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Persistence;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ClientDbContext>
{
    public ClientDbContext CreateDbContext(string[] args)
    {
        var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

        var cwd = Directory.GetCurrentDirectory();
        var candidates = new[]
        {
            cwd,
            Path.Combine(cwd, "src", "WebApi"),
            Path.GetFullPath(Path.Combine(cwd, "..", "WebApi"))
        };
        var basePath = candidates.FirstOrDefault(p => File.Exists(Path.Combine(p, "appsettings.json"))) ?? cwd;

        var configuration = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json", optional: true)
            .AddJsonFile($"appsettings.{env}.json", optional: true)
            .Build();

        var conn = configuration.GetConnectionString("Default")
                  ?? Environment.GetEnvironmentVariable("ORACLE_CONNECTION_STRING")
                  ?? "User Id=hr;Password=hr;Data Source=localhost/XEPDB1";

        var optionsBuilder = new DbContextOptionsBuilder<ClientDbContext>();
        optionsBuilder.UseOracle(conn);
        return new ClientDbContext(optionsBuilder.Options);
    }
}
