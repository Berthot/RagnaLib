using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RagnaLib.Domain.Entities;

namespace RagnaLib.Infra.Data.Mappings;

public static class SubTypeMapping
{
    public static void MappingSubType(this EntityTypeBuilder<SubType> entity)
    {
            entity.HasKey(x => x.Id)
                .HasName("PK_SUB_TYPE");
            entity.ToTable("SubType");

            entity.Property(x => x.Id)
                .UseIdentityColumn();

            entity.Property(x => x.Name)
                .IsRequired();
            
            entity.Property(x => x.Location)
                .IsRequired();

        }
}