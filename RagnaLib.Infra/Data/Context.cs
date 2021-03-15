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
        public DbSet<Map> Maps { get; set; }
        public DbSet<Monster> Monsters { get; set; }
        public DbSet<Status> Status { get; set; }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // new DbMapping(builder);
            base.OnModelCreating(builder);
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("RAGNAROK") ?? "");
            // services.AddDbContext<Context>(opt => opt.UseInMemoryDatabase("EMPLOYER"));
        }
        
    }
}