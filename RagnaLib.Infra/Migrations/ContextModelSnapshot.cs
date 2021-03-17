﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RagnaLib.Infra.Data;

namespace RagnaLib.Infra.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("RagnaLib.Domain.Entities.Element", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<short>("Dark")
                        .HasColumnType("smallint");

                    b.Property<short>("Earth")
                        .HasColumnType("smallint");

                    b.Property<short>("Fire")
                        .HasColumnType("smallint");

                    b.Property<short>("Ghost")
                        .HasColumnType("smallint");

                    b.Property<short>("Holy")
                        .HasColumnType("smallint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<short>("Neutral")
                        .HasColumnType("smallint");

                    b.Property<short>("Poison")
                        .HasColumnType("smallint");

                    b.Property<short>("Tier")
                        .HasColumnType("smallint");

                    b.Property<short>("Undead")
                        .HasColumnType("smallint");

                    b.Property<short>("Water")
                        .HasColumnType("smallint");

                    b.Property<short>("Wind")
                        .HasColumnType("smallint");

                    b.HasKey("Id")
                        .HasName("PK_ELEMENT");

                    b.ToTable("Element");
                });

            modelBuilder.Entity("RagnaLib.Domain.Entities.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CardImageUrl")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text");

                    b.Property<int>("ItemTypeId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Price")
                        .HasColumnType("text");

                    b.Property<string>("SmallImageUrl")
                        .HasColumnType("text");

                    b.Property<int>("SubTypeId")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("PK_ITEM");

                    b.HasIndex("ItemTypeId");

                    b.HasIndex("SubTypeId");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("RagnaLib.Domain.Entities.ItemType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id")
                        .HasName("PK_ITEM_TYPE");

                    b.ToTable("ItemType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Consumable"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Armor"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Weapon"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Ammo"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Card"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Costume"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Other"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Shadow Equipment"
                        });
                });

            modelBuilder.Entity("RagnaLib.Domain.Entities.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("MapCleanUrl")
                        .HasColumnType("text");

                    b.Property<string>("MapUrl")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NameId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("Id")
                        .HasName("PK_LOCATION");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("RagnaLib.Domain.Entities.Monster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ElementId")
                        .HasColumnType("integer");

                    b.Property<string>("GifUrl")
                        .HasColumnType("text");

                    b.Property<bool>("HasDrop")
                        .HasColumnType("boolean");

                    b.Property<bool>("HasLocation")
                        .HasColumnType("boolean");

                    b.Property<int>("Health")
                        .HasColumnType("integer");

                    b.Property<int>("Level")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Race")
                        .HasColumnType("integer");

                    b.Property<int>("Size")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("PK_MONSTER");

                    b.HasIndex("ElementId");

                    b.ToTable("Monster");
                });

            modelBuilder.Entity("RagnaLib.Domain.Entities.MonsterItemMap", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("DropRate")
                        .HasColumnType("integer");

                    b.Property<int>("ItemId")
                        .HasColumnType("integer");

                    b.Property<int>("MonsterId")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("PK_MONSTER_ITEM_MAP");

                    b.HasIndex("ItemId");

                    b.HasIndex("MonsterId");

                    b.ToTable("MonsterItemMap");
                });

            modelBuilder.Entity("RagnaLib.Domain.Entities.MonsterPerLocationMap", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("LocationId")
                        .HasColumnType("integer");

                    b.Property<int>("MonsterId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.HasKey("Id")
                        .HasName("PK_MONSTER_PER_LOCATION_MAP");

                    b.HasIndex("LocationId");

                    b.HasIndex("MonsterId");

                    b.ToTable("MonsterPerLocationMap");
                });

            modelBuilder.Entity("RagnaLib.Domain.Entities.SubType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id")
                        .HasName("PK_SUB_TYPE");

                    b.ToTable("SubType");
                });

            modelBuilder.Entity("RagnaLib.Domain.Entities.Item", b =>
                {
                    b.HasOne("RagnaLib.Domain.Entities.ItemType", "ItemType")
                        .WithMany("Items")
                        .HasForeignKey("ItemTypeId")
                        .HasConstraintName("FK_ITEM_ITEMTYPE")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RagnaLib.Domain.Entities.SubType", "SubType")
                        .WithMany("Items")
                        .HasForeignKey("SubTypeId")
                        .HasConstraintName("FK_ITEM_SUBTYPE")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ItemType");

                    b.Navigation("SubType");
                });

            modelBuilder.Entity("RagnaLib.Domain.Entities.Monster", b =>
                {
                    b.HasOne("RagnaLib.Domain.Entities.Element", "Element")
                        .WithMany("Monsters")
                        .HasForeignKey("ElementId")
                        .HasConstraintName("FK_MONSTER_ELEMENT")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Element");
                });

            modelBuilder.Entity("RagnaLib.Domain.Entities.MonsterItemMap", b =>
                {
                    b.HasOne("RagnaLib.Domain.Entities.Item", "Item")
                        .WithMany("MonsterItemMaps")
                        .HasForeignKey("ItemId")
                        .HasConstraintName("FK_MOSTERITEMMAP_ITEM")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RagnaLib.Domain.Entities.Monster", "Monster")
                        .WithMany("MonsterItemMaps")
                        .HasForeignKey("MonsterId")
                        .HasConstraintName("FK_MOSTERITEMMAP_MONSTER")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Monster");
                });

            modelBuilder.Entity("RagnaLib.Domain.Entities.MonsterPerLocationMap", b =>
                {
                    b.HasOne("RagnaLib.Domain.Entities.Location", "Location")
                        .WithMany("MonsterPerLocationMaps")
                        .HasForeignKey("LocationId")
                        .HasConstraintName("FK_MONSTERPERLOCATION_LOCATION")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RagnaLib.Domain.Entities.Monster", "Monster")
                        .WithMany("MonsterPerLocationMaps")
                        .HasForeignKey("MonsterId")
                        .HasConstraintName("FK_MONSTERPERLOCATION_MONSTER")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Location");

                    b.Navigation("Monster");
                });

            modelBuilder.Entity("RagnaLib.Domain.Entities.Element", b =>
                {
                    b.Navigation("Monsters");
                });

            modelBuilder.Entity("RagnaLib.Domain.Entities.Item", b =>
                {
                    b.Navigation("MonsterItemMaps");
                });

            modelBuilder.Entity("RagnaLib.Domain.Entities.ItemType", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("RagnaLib.Domain.Entities.Location", b =>
                {
                    b.Navigation("MonsterPerLocationMaps");
                });

            modelBuilder.Entity("RagnaLib.Domain.Entities.Monster", b =>
                {
                    b.Navigation("MonsterItemMaps");

                    b.Navigation("MonsterPerLocationMaps");
                });

            modelBuilder.Entity("RagnaLib.Domain.Entities.SubType", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
