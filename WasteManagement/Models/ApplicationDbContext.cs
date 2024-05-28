using Microsoft.EntityFrameworkCore;

namespace WasteManagement.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<WasteBin> WasteBins { get; set; }
        public DbSet<WasteCollection> WasteCollections { get; set; }
    }
}
