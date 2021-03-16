using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RagnaLib.Domain.Entities;

namespace RagnaLib.Infra.Data.Mappings
{
    public static class ItemMapping
    {
        public static void MappingItem(this EntityTypeBuilder<Item> entity)
        {
            entity.HasKey(x => x.Id)
                .HasName("PK_ITEM");
            entity.ToTable("Item");

            entity.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            entity.Property(x => x.Name)
                .IsRequired();

            entity.Property(x => x.Price);

            entity.Property(x => x.ImageUrl);

            entity.Property(x => x.SmallImageUrl);

            entity.Property(x => x.CardImageUrl);

            entity.Property(x => x.Description);

            entity.HasOne(x => x.ItemType)
                .WithMany(y => y.Items)
                .HasForeignKey(z => z.ItemTypeId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_ITEM_ITEMTYPE");
            
            
            entity.HasOne(x => x.SubType)
                .WithMany(y => y.Items)
                .HasForeignKey(z => z.SubTypeId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_ITEM_SUBTYPE");
        }
    }
}