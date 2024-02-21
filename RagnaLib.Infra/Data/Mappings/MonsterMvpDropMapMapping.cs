using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RagnaLib.Domain.Entities;

namespace RagnaLib.Infra.Data.Mappings;

public static class MonsterMvpDropMapMapping
{
    public static void MappingMonsterMvpDropMap(this EntityTypeBuilder<MonsterMvpDropMap> entity)
    {

        entity.HasKey(x => x.Id)
            .HasName("PK_MONSTER_MVP_DROP_MAP");
        entity.ToTable("MonsterMvpDropMap");

        entity.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();
            
        entity.Property(x => x.Stealable);
            
        entity.Property(x => x.DropRate);

        entity.HasOne(x => x.Monster)
            .WithMany(y => y.MonsterMvpDropMaps)
            .HasForeignKey(z => z.MonsterId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_MONSTERMVPDROPMAP_MONSTER");

        entity.HasOne(x => x.Item)
            .WithMany(y => y.MonsterMvpDropMaps)
            .HasForeignKey(z => z.ItemId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_MONSTERMVPDROPMAP_ITEM");
    }
}