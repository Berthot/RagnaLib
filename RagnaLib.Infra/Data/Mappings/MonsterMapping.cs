using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RagnaLib.Domain.Entities;

namespace RagnaLib.Infra.Data.Mappings;

public static class MonsterMapping
{
    public static void MappingMonster(this EntityTypeBuilder<Monster> entity)
    {
            entity.HasKey(x => x.Id)
                .HasName("PK_MONSTER");
            entity.ToTable("Monster");

            entity.Property(x => x.Id)
                .UseIdentityColumn();

            entity.Property(x => x.Name)
                .IsRequired();

            entity.Property(x => x.DbName);

            entity.Property(x => x.Level)
                .IsRequired();

            entity.Property(x => x.Health)
                .IsRequired();

            entity.Property(x => x.Size)
                .IsRequired();

            entity.Property(x => x.HasDrop);

            entity.Property(x => x.HasLocation);

            entity.Property(x => x.GifUrl);
            entity.Property(x => x.IsMvp);
            
            
            entity.OwnsOne(o => o.PrimaryAttribute,
                sa =>
                {
                    sa.Property(p => p.Str).HasColumnName("Str").IsRequired();
                    sa.Property(p => p.Agi).HasColumnName("Agi").IsRequired();
                    sa.Property(p => p.Vit).HasColumnName("Vit").IsRequired();
                    sa.Property(p => p.Int).HasColumnName("Int").IsRequired();
                    sa.Property(p => p.Dex).HasColumnName("Dex").IsRequired();
                    sa.Property(p => p.Luk).HasColumnName("Luk").IsRequired();
                });

            entity.OwnsOne(o => o.SecondaryAttribute,
                sa =>
                {
                    sa.Property(p => p.Hp).HasColumnName("Hp");
                    sa.Property(p => p.Sp).HasColumnName("Sp");
                    sa.Property(p => p.Flee).HasColumnName("Flee");
                    sa.Property(p => p.Hit).HasColumnName("Hit");
                    sa.Property(p => p.AttackSpeed).HasColumnName("AttackSpeed");
                    sa.Property(p => p.AttackRange).HasColumnName("AttackRange");
                });

            entity.OwnsOne(o => o.PhysicalAttack,
                sa =>
                {
                    sa.Property(p => p.MinimalDamage).HasColumnName("MinimumPhysicalAttack").IsRequired();
                    sa.Property(p => p.MaximumDamage).HasColumnName("MaximumPhysicalAttack").IsRequired();
                });
            
            entity.OwnsOne(o => o.Experience,
                sa =>
                {
                    sa.Property(p => p.Base).HasColumnName("BaseExperience").IsRequired();
                    sa.Property(p => p.Job).HasColumnName("JobExperience").IsRequired();
                });
            
            entity.OwnsOne(o => o.Defense,
                sa =>
                {
                    sa.Property(p => p.MagicDefense).HasColumnName("MagicDefense").IsRequired();
                    sa.Property(p => p.PhysicalDefense).HasColumnName("PhysicalDefense").IsRequired();
                });

            entity.OwnsOne(o => o.MagicAttack,
                sa =>
                {
                    sa.Property(p => p.MinimalDamage).HasColumnName("MinimumMagicAttack").IsRequired();
                    sa.Property(p => p.MaximumDamage).HasColumnName("MaximumMagicAttack").IsRequired();
                });

            entity.HasOne(x => x.Element)
                .WithMany(y => y.Monsters)
                .HasForeignKey(z => z.ElementId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_MONSTER_ELEMENT");

            entity.HasOne(x => x.Race)
                .WithMany(y => y.Monsters)
                .HasForeignKey(z => z.RaceId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_MONSTER_RACE");

            entity.HasOne(x => x.Scale)
                .WithMany(y => y.Monsters)
                .HasForeignKey(z => z.ScaleId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_MONSTER_SCALE");
        }
}

// public int Id { get; set; }
// public string Name { get; set; }
// public string GifUrl { get; set; }
// public int ElementId { get; set; }
// public List<MonsterPerLocationMap> MonsterPerLocationMaps { get; set; }
// public List<MonsterItemMap> MonsterItemMaps { get; set; }
// public virtual Element Element { get; set; }