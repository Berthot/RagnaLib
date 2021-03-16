using System;
using Microsoft.EntityFrameworkCore;
using RagnaLib.Domain.Entities;

namespace RagnaLib.Infra.Data
{
    public class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> builderOptions) : base(builderOptions)
        {
        }


        public DbSet<Element> Elements { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemType> ItemTypes { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Monster> Monsters { get; set; }
        public DbSet<MonsterItemMap> MonsterItemMaps { get; set; }
        public DbSet<MonsterPerLocationMap> MonsterPerLocationMaps { get; set; }
        public DbSet<SubType> SubTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.SetMapping();
            builder.SetSeed();
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("RAGNAROK") ?? "");
            // services.AddDbContext<Context>(opt => opt.UseInMemoryDatabase("EMPLOYER"));
        }
    }
}