using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RagnaLib.Domain.Entities;

namespace RagnaLib.Infra.Data.Mappings;

public static class MonsterPerLocationMapMapping
{
    public static void MappingMonsterPerLocationMap(this EntityTypeBuilder<MonsterPerLocationMap> entity)
    {
            entity.HasKey(x => x.Id)
                .HasName("PK_MONSTER_PER_LOCATION_MAP");
            entity.ToTable("MonsterPerLocationMap");

            entity.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            entity.Property(x => x.Quantity)
                .HasDefaultValue(0)
                .IsRequired();
            entity.Property(x => x.RespawnTime);


            entity.HasOne(x => x.Monster)
                .WithMany(y => y.MonsterPerLocationMaps)
                .HasForeignKey(z => z.MonsterId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_MONSTERPERLOCATION_MONSTER");

            entity.HasOne(x => x.Location)
                .WithMany(y => y.MonsterPerLocationMaps)
                .HasForeignKey(z => z.LocationId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_MONSTERPERLOCATION_LOCATION");
        }
}