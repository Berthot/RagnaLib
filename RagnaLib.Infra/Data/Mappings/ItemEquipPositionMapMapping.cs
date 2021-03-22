using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RagnaLib.Domain.Entities;

namespace RagnaLib.Infra.Data.Mappings
{
    public static class ItemEquipPositionMapMapping
    {
        public static void MappingItemEquipPositionMap(this EntityTypeBuilder<ItemEquipPositionMap> entity)
        {

            entity.HasKey(x => x.Id)
                .HasName("PK_ITEM_EQUIP_POSITION_MAP");
            entity.ToTable("ItemEquipPositionMap");

            entity.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            entity.HasOne(x => x.Item)
                .WithMany(y => y.ItemEquipPositionMaps)
                .HasForeignKey(z => z.ItemId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_ITEMEQUIPPOSITIONMAP_ITEM");

            entity.HasOne(x => x.EquipPosition)
                .WithMany(y => y.ItemEquipPositionMaps)
                .HasForeignKey(z => z.EquipPositionId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_ITEMEQUIPPOSITIONMAP_EQUIPEPOSITION");
        }
    }
}

// public int Id { get; set; }
// public int ItemId { get; set; }
// public int EquipPositionId { get; set; }
// public virtual Item Item { get; set; }
// public virtual EquipPosition EquipPosition { get; set; }