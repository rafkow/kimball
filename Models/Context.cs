using Microsoft.EntityFrameworkCore;

namespace Kimball.Models {
    public class Context : DbContext {
        public DbSet<Record> Records { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source=sql.db");
    }
}
