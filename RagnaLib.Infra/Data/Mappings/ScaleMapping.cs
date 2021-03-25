using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RagnaLib.Domain.Entities;

namespace RagnaLib.Infra.Data.Mappings
{
    public static class ScaleMapping
    {
        public static void MappingScale(this EntityTypeBuilder<Scale> entity)
        {

            entity.HasKey(x => x.Id)
                .HasName("PK_SCALE");
            entity.ToTable("Scale");

            entity.Property(x => x.Id)
                .UseIdentityColumn();

            entity.Property(x => x.Name).IsRequired();
        }
    }
}