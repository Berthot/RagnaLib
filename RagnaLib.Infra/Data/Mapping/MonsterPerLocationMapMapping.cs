using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RagnaLib.Domain.Entities;

namespace RagnaLib.Infra.Data.Mapping
{
    public class MonsterPerLocationMapMapping
    {
        public MonsterPerLocationMapMapping(EntityTypeBuilder<MonsterPerLocationMap> entity)
        {
            entity.HasKey(x => x.Id)
                .HasName("PK_MONSTER_PER_LOCATION_MAP");
            entity.ToTable("MonsterPerLocationMap");

            entity.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();
            entity.Property(x => x.Quantity)
                .IsRequired();
            
            
        }
        // public int MonsterId { get; set; }
        // public int LocationId { get; set; }
        // public int Quantity { get; set; }
    }
}