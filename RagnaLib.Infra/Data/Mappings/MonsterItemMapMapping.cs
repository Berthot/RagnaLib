using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RagnaLib.Domain.Entities;

namespace RagnaLib.Infra.Data.Mappings;

public static class MonsterItemMapMapping
{
    public static void MappingMonsterItemMap(this EntityTypeBuilder<MonsterItemMap> entity)
    {
        entity.HasKey(x => x.Id)
            .HasName("PK_MONSTER_ITEM_MAP");
        entity.ToTable("MonsterItemMap");

        entity.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        entity.Property(x => x.DropRate)
            .IsRequired();
            
        entity.Property(x => x.Stealable)
            .IsRequired();

        entity.HasOne(x => x.Monster)
            .WithMany(y => y.MonsterItemMaps)
            .HasForeignKey(z => z.MonsterId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_MOSTERITEMMAP_MONSTER");

        entity.HasOne(x => x.Item)
            .WithMany(y => y.MonsterItemMaps)
            .HasForeignKey(z => z.ItemId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_MOSTERITEMMAP_ITEM");
    }
}