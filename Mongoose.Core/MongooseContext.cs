using Microsoft.EntityFrameworkCore;
using Mongoose.Core.Entities;

namespace Mongoose.Core
{
    public class MongooseContext : DbContext
    {
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Series> Series { get; set; }
        public MongooseContext(DbContextOptions options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Episode>()
                .HasIndex(s => s.FilePath);
            modelBuilder.Entity<Series>()
                .HasIndex(s => s.Name)
                .IsUnique();
        }
    }
}