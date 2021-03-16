using Microsoft.EntityFrameworkCore;
using Mongoose.Core.Entities;

namespace Mongoose.Core
{
    public class MongooseContext : DbContext
    {
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<VideoInfo> VideoInfo { get; set; }
        public MongooseContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Series>()
                .HasIndex(s => s.Name)
                .IsUnique();
            modelBuilder.Entity<VideoInfo>()
                .HasIndex(vi => vi.FilePath)
                .IsUnique();
            modelBuilder.Entity<Episode>()
                .HasOne<VideoInfo>()
                .WithOne(vi => vi.Episode)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Film>()
                .HasOne<VideoInfo>()
                .WithOne(vi => vi.Film)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}