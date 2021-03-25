using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RagnaLib.Domain.Entities;

namespace RagnaLib.Infra.Data.Mappings
{
    public static class ElementMapping
    {
        public static void MappingElement(this EntityTypeBuilder<Element> entity)
        {
            entity.HasKey(x => x.Id)
                .HasName("PK_ELEMENT");
            entity.ToTable("Element");

            entity.Property(x => x.Id)
                .UseIdentityColumn();

            entity.Property(x => x.Name)
                .IsRequired();

            entity.Property(x => x.Tier)
                .IsRequired();

            entity.Property(x => x.Neutral)
                .IsRequired();

            entity.Property(x => x.Water)
                .IsRequired();

            entity.Property(x => x.Earth)
                .IsRequired();

            entity.Property(x => x.Fire)
                .IsRequired();

            entity.Property(x => x.Wind)
                .IsRequired();

            entity.Property(x => x.Poison)
                .IsRequired();

            entity.Property(x => x.Holy)
                .IsRequired();

            entity.Property(x => x.Dark)
                .IsRequired();

            entity.Property(x => x.Ghost)
                .IsRequired();

            entity.Property(x => x.Undead)
                .IsRequired();
        }
    }
}