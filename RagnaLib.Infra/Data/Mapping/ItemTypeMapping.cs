using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RagnaLib.Domain.Entities;

namespace RagnaLib.Infra.Data.Mapping
{
    public class ItemTypeMapping
    {

        public ItemTypeMapping(EntityTypeBuilder<ItemType> entity)
        {
            entity.HasKey(x => x.Id)
                .HasName("PK_ITEM_TYPE");
            entity.ToTable("ItemType");

            entity.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            entity.Property(x => x.Name)
                .IsRequired();

            entity.Property(x => x.SubType)
                .IsRequired();
            
        }
        
    }
    // public int Id { get; set; }
    // public string Name { get; set; }
    // public SubType SubType { get; set; }
}