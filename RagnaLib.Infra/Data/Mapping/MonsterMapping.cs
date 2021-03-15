using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RagnaLib.Domain.Entities;

namespace RagnaLib.Infra.Data.Mapping
{
    public class MonsterMapping
    {
        public MonsterMapping(EntityTypeBuilder<Monster> entity)
        {
            entity.HasKey(x => x.Id)
                .HasName("PK_MONSTER");
            entity.ToTable("Monster");

            entity.Property(x => x.Id)
                .UseIdentityColumn();

            entity.Property(x => x.Name)
                .IsRequired();
            
            entity.Property(x => x.Level)
                .IsRequired();
            
            entity.Property(x => x.Health)
                .IsRequired();
            
            entity.Property(x => x.Race)
                .IsRequired();
            
            entity.Property(x => x.Size)
                .IsRequired();

            entity.Property(x => x.GifUrl);

            entity.HasOne(x => x.Element)
                .WithMany(y => y.Monsters)
                .HasForeignKey(z => z.ElementId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_MONSTER_ELEMENT");
        }
    }
    // public int Id { get; set; }
    // public string Name { get; set; }
    // public string GifUrl { get; set; }
    // public int ElementId { get; set; }
    // public List<MonsterPerLocationMap> MonsterPerLocationMaps { get; set; }
    // public List<MonsterItemMap> MonsterItemMaps { get; set; }
    // public virtual Element Element { get; set; }
}