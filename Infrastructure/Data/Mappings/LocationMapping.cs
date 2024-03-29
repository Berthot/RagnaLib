using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Infrastructure.Data.Mappings;

public static class LocationMapping
{
    public static void MappingLocation(this EntityTypeBuilder<Location> entity)
    {
        entity.HasKey(x => x.Id)
            .HasName("PK_LOCATION");
        entity.ToTable("Location");

        entity.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        entity.Property(x => x.NameId)
            .IsRequired();

        entity.Property(x => x.Name)
            .IsRequired();

        entity.Property(x => x.Type);

        entity.Property(x => x.MapUrl);

        entity.Property(x => x.MapCleanUrl);
    }

    // public string Name { get; set; }
    // public string Id { get; set; }
    // public string MapUrl { get; set; } // https://www.divine-pride.net/img/map/original/gef_fild10
    // public string MapCleanUrl { get; set; } // https://www.divine-pride.net/img/map/raw/gef_fild10
    // public IEnumerable<Monster> Monsters { get; set; }
}