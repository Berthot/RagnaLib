using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Infrastructure.Data.Mappings;

public static class ItemTypeMapping
{
    public static void MappingItemType(this EntityTypeBuilder<ItemType> entity)
    {
        entity.HasKey(x => x.Id)
            .HasName("PK_ITEM_TYPE");
        entity.ToTable("ItemType");

        entity.Property(x => x.Id)
            .UseIdentityColumn();

        entity.Property(x => x.Name)
            .IsRequired();

    }
}

// public int Id { get; set; }
// public string Name { get; set; }
// public SubType SubType { get; set; }