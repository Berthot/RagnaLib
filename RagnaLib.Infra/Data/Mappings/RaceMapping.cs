using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RagnaLib.Domain.Entities;

namespace RagnaLib.Infra.Data.Mappings;

public static class RaceMapping
{
    public static void MappingRace(this EntityTypeBuilder<Race> entity)
    {

            entity.HasKey(x => x.Id)
                .HasName("PK_RACE");
            entity.ToTable("Race");

            entity.Property(x => x.Id)
                .UseIdentityColumn();

            entity.Property(x => x.Name)
                .IsRequired();
            
            entity.Property(x => x.EnName);
        }
}