using Domain;

using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DB
{
    public interface IDbContext : IDisposable
    {
        DbSet<DiagnosticsDTO> Diagnostics { get; set; }

        Task<int> SaveChangesAsync();
    }

    public class DemoDBContext : DbContext, IDbContext
    {
        public DemoDBContext(DbContextOptions<DemoDBContext> options) : base(options)
        {
        }

        public DbSet<DiagnosticsDTO> Diagnostics { get; set; }
        
        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
