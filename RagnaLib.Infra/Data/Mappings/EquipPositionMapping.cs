using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RagnaLib.Domain.Entities;

namespace RagnaLib.Infra.Data.Mappings
{
    public static class EquipPositionMapping
    {
        public static void MappingEquipPosition(this EntityTypeBuilder<EquipPosition> entity)
        {
            
            entity.HasKey(x => x.Id)
                .HasName("PK_EQUIP_POSITION");
            entity.ToTable("EquipPosition");

            entity.Property(x => x.Id)
                .UseIdentityColumn();

            entity.Property(x => x.Position)
                .IsRequired();

            entity.Property(x => x.Description);
        }
    }
}