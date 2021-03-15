using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RagnaLib.Domain.Entities;

namespace RagnaLib.Infra.Data.Mapping
{
    public class ItemMapping
    {
        public ItemMapping(EntityTypeBuilder<Item> entity)
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
            
        }
    }
    // public ItemType ItemTypeId { get; set; }
    // public ItemType ItemType { get; set; }
}