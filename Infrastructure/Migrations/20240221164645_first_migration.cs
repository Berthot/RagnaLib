using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class first_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Element",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Tier = table.Column<short>(type: "smallint", nullable: false),
                    Neutral = table.Column<short>(type: "smallint", nullable: false),
                    Water = table.Column<short>(type: "smallint", nullable: false),
                    Earth = table.Column<short>(type: "smallint", nullable: false),
                    Fire = table.Column<short>(type: "smallint", nullable: false),
                    Wind = table.Column<short>(type: "smallint", nullable: false),
                    Poison = table.Column<short>(type: "smallint", nullable: false),
                    Holy = table.Column<short>(type: "smallint", nullable: false),
                    Dark = table.Column<short>(type: "smallint", nullable: false),
                    Ghost = table.Column<short>(type: "smallint", nullable: false),
                    Undead = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ELEMENT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EquipPosition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Position = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EQUIP_POSITION", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ITEM_TYPE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NameId = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    MapUrl = table.Column<string>(type: "text", nullable: true),
                    MapCleanUrl = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOCATION", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Race",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    EnName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Race", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Scales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUB_TYPE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Monster",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    DbName = table.Column<string>(type: "text", nullable: true),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    Health = table.Column<int>(type: "integer", nullable: false),
                    Size = table.Column<int>(type: "integer", nullable: false),
                    GifUrl = table.Column<string>(type: "text", nullable: true),
                    ElementId = table.Column<int>(type: "integer", nullable: false),
                    HasDrop = table.Column<bool>(type: "boolean", nullable: false),
                    HasLocation = table.Column<bool>(type: "boolean", nullable: false),
                    IsMvp = table.Column<bool>(type: "boolean", nullable: false),
                    RaceId = table.Column<int>(type: "integer", nullable: false),
                    ScaleId = table.Column<int>(type: "integer", nullable: false),
                    BaseExperience = table.Column<int>(type: "integer", nullable: true),
                    JobExperience = table.Column<int>(type: "integer", nullable: true),
                    MinimumPhysicalAttack = table.Column<int>(type: "integer", nullable: true),
                    MaximumPhysicalAttack = table.Column<int>(type: "integer", nullable: true),
                    MinimumMagicAttack = table.Column<int>(type: "integer", nullable: true),
                    MaximumMagicAttack = table.Column<int>(type: "integer", nullable: true),
                    MagicDefense = table.Column<int>(type: "integer", nullable: true),
                    PhysicalDefense = table.Column<int>(type: "integer", nullable: true),
                    Str = table.Column<int>(type: "integer", nullable: true),
                    Agi = table.Column<int>(type: "integer", nullable: true),
                    Vit = table.Column<int>(type: "integer", nullable: true),
                    Int = table.Column<int>(type: "integer", nullable: true),
                    Dex = table.Column<int>(type: "integer", nullable: true),
                    Luk = table.Column<int>(type: "integer", nullable: true),
                    Hp = table.Column<int>(type: "integer", nullable: true),
                    Sp = table.Column<int>(type: "integer", nullable: true),
                    Flee = table.Column<int>(type: "integer", nullable: true),
                    Hit = table.Column<int>(type: "integer", nullable: true),
                    AttackSpeed = table.Column<float>(type: "real", nullable: true),
                    AttackRange = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MONSTER", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MONSTER_ELEMENT",
                        column: x => x.ElementId,
                        principalTable: "Element",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MONSTER_RACE",
                        column: x => x.RaceId,
                        principalTable: "Race",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MONSTER_SCALE",
                        column: x => x.ScaleId,
                        principalTable: "Scales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<string>(type: "text", nullable: true),
                    SmallImageUrl = table.Column<string>(type: "text", nullable: true),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    CardImageUrl = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ItemTypeId = table.Column<int>(type: "integer", nullable: false),
                    SubTypeId = table.Column<int>(type: "integer", nullable: false),
                    Refinable = table.Column<bool>(type: "boolean", nullable: false),
                    Attack = table.Column<int>(type: "integer", nullable: false),
                    MagicAttack = table.Column<int>(type: "integer", nullable: false),
                    RequiredLevel = table.Column<int>(type: "integer", nullable: false),
                    LimitLevel = table.Column<int>(type: "integer", nullable: false),
                    ItemLevel = table.Column<int>(type: "integer", nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    Defense = table.Column<int>(type: "integer", nullable: false),
                    Slots = table.Column<int>(type: "integer", nullable: false),
                    UnidName = table.Column<string>(type: "text", nullable: true),
                    CardPrefix = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ITEM", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ITEM_ITEMTYPE",
                        column: x => x.ItemTypeId,
                        principalTable: "ItemType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ITEM_SUBTYPE",
                        column: x => x.SubTypeId,
                        principalTable: "SubType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MonsterPerLocationMap",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MonsterId = table.Column<int>(type: "integer", nullable: false),
                    LocationId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    RespawnTime = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MONSTER_PER_LOCATION_MAP", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MONSTERPERLOCATION_LOCATION",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MONSTERPERLOCATION_MONSTER",
                        column: x => x.MonsterId,
                        principalTable: "Monster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemEquipPositionMap",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ItemId = table.Column<int>(type: "integer", nullable: false),
                    EquipPositionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ITEM_EQUIP_POSITION_MAP", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ITEMEQUIPPOSITIONMAP_EQUIPEPOSITION",
                        column: x => x.EquipPositionId,
                        principalTable: "EquipPosition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ITEMEQUIPPOSITIONMAP_ITEM",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MonsterItemMap",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MonsterId = table.Column<int>(type: "integer", nullable: false),
                    ItemId = table.Column<int>(type: "integer", nullable: false),
                    DropRate = table.Column<int>(type: "integer", nullable: false),
                    Stealable = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MONSTER_ITEM_MAP", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MOSTERITEMMAP_ITEM",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MOSTERITEMMAP_MONSTER",
                        column: x => x.MonsterId,
                        principalTable: "Monster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MonsterMvpDropMaps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MonsterId = table.Column<int>(type: "integer", nullable: false),
                    ItemId = table.Column<int>(type: "integer", nullable: false),
                    Stealable = table.Column<bool>(type: "boolean", nullable: false),
                    DropRate = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonsterMvpDropMaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonsterMvpDropMaps_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MonsterMvpDropMaps_Monster_MonsterId",
                        column: x => x.MonsterId,
                        principalTable: "Monster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EquipPosition",
                columns: new[] { "Id", "Description", "Position" },
                values: new object[,]
                {
                    { -1, "-", "Unknown" },
                    { 1, "Accessory", "Accessory" },
                    { 2, "Accessory", "Accessory (Left)" },
                    { 3, "Accessory", "Accessory (Right)" },
                    { 4, "Armor", "Body" },
                    { 5, "Boath Hand", "Both Hand" },
                    { 6, "Garment", "Garment" },
                    { 7, "Shield", "Left Hand" },
                    { 8, "Shoes", "Shoes" },
                    { 9, "Weapon", "Right Hand" },
                    { 10, "Shadow Weapon", "Shadow Weapon" },
                    { 11, "Shadow Acessory", "Right Shadow Accessory" },
                    { 12, "Shadow Armor", "Shadow Armor" },
                    { 13, "Shadow Shield", "Shadow Shield" },
                    { 14, "Shadow Shoes", "Shadow Shoes" },
                    { 15, "Shadow Acessory", "Left Shadow Accessory" },
                    { 16, "Costume", "Lower Costume Headgear" },
                    { 17, "Costume", "Middle Costume Headgear" },
                    { 18, "Costume", "Upper Costume Headgear" },
                    { 19, "Costume", "Middle/Lower Costume Headgear" },
                    { 20, "Costume", "Upper/Lower Costume Headgear" },
                    { 21, "Costume", "Upper/Middle Costume Headgear" },
                    { 22, "Costume", "Upper/Middle/Lower Costume Headgear" },
                    { 23, "Costume Garment", "Costume Garment" },
                    { 24, "Headgear", "Lower Headgear" },
                    { 25, "Headgear", "Middle Headgear" },
                    { 26, "Headgear", "Upper Headgear" },
                    { 27, "Headgear", "Upper/Middle/Lower Headgear" },
                    { 28, "Headgear", "Upper/Middle Headgear" },
                    { 29, "Headgear", "Upper/Lower Headgear" },
                    { 30, "Headgear", "Middle/Lower Headgear" },
                    { 31, "Enchant", "Enchant" }
                });

            migrationBuilder.InsertData(
                table: "ItemType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { -1, "Unknown" },
                    { 1, "Weapon" },
                    { 2, "Armor" },
                    { 3, "Consumable" },
                    { 4, "Ammo" },
                    { 5, "Etc." },
                    { 6, "Cash" },
                    { 7, "Costume" },
                    { 8, "Shadow Equipment" },
                    { 9, "Card" }
                });

            migrationBuilder.InsertData(
                table: "Race",
                columns: new[] { "Id", "EnName", "Name" },
                values: new object[,]
                {
                    { 1, "formless", "amorfo" },
                    { 2, "angel", "anjo" },
                    { 3, "brute", "bruto" },
                    { 4, "demon", "demônio" },
                    { 5, "dragon", "dragão" },
                    { 6, "human", "humanoide" },
                    { 7, "insect", "inseto" },
                    { 8, "undead", "morto-vivo" },
                    { 9, "fish", "peixe" },
                    { 10, "plant", "planta" },
                    { 11, "null", "doram" },
                    { 12, "null", "humano" }
                });

            migrationBuilder.InsertData(
                table: "Scales",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "small" },
                    { 2, "medium" },
                    { 3, "large" }
                });

            migrationBuilder.InsertData(
                table: "SubType",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { -1, "-", "Unknown" },
                    { 1, "Right Hand", "Dagger" },
                    { 2, "Right Hand", "Sword" },
                    { 3, "Both hand", "Two-handed Sword" },
                    { 4, "Right Hand", "Spear" },
                    { 5, "Both hand", "Two-handed Spear" },
                    { 6, "Right Hand", "Axe" },
                    { 7, "Both hand", "Two-handed Axe" },
                    { 8, "Right Hand", "Mace" },
                    { 9, "Right Hand", "Rod" },
                    { 10, "Both hand", "Two-handed Rod" },
                    { 11, "Both hand", "Bow" },
                    { 12, "Right Hand", "Fist weapon" },
                    { 13, "Right Hand", "Instrument" },
                    { 14, "Right Hand", "Whip" },
                    { 15, "Right Hand", "Book" },
                    { 16, "Both hand", "Katar" },
                    { 17, "Both hand", "Gatling Gun" },
                    { 18, "Both hand", "Shotgun" },
                    { 19, "Both hand", "Grenade Launcher" },
                    { 20, "Both hand", "Shuriken" },
                    { 21, "Accessory", "Accessory" },
                    { 22, "Accessory", "Accessory (Right)" },
                    { 23, "Accessory", "Accessory (Left)" },
                    { 24, "Middle Headgear", "Helm" },
                    { 25, "Body", "Armor" },
                    { 26, "Garment", "Garment" },
                    { 27, "Shoes", "Shoes" },
                    { 28, "-", "Pet" },
                    { 29, "-", "Special" },
                    { 30, "-", "Regeneration" },
                    { 31, "-", "Taming item" },
                    { 32, "-", "Arrow" },
                    { 33, "-", "Cannonball" },
                    { 34, "-", "Throw Weapon" },
                    { 35, "-", "Ammo" },
                    { 36, "-", "-" },
                    { 37, "-", "Pistol" },
                    { 38, "-", "Rifle" },
                    { 39, "Left Hand", "Shield" },
                    { 40, "Costume Garment", "Costume Garment" },
                    { 41, "Shadow Weapon", "Shadow Weapon" },
                    { 42, "Shadow Armor", "Shadow Armor" },
                    { 43, "Shadow Shield", "Shadow Shield" },
                    { 44, "Shadow Shoes", "Shadow Shoes" },
                    { 45, "Right Shadow Accessory", "Shadow Acc. (Right)" },
                    { 46, "Left Shadow Accessory", "Shadow Acc. (Left)" },
                    { 47, "Upper Costume Headgear", "Costume Helm" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Item_ItemTypeId",
                table: "Item",
                column: "ItemTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_SubTypeId",
                table: "Item",
                column: "SubTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemEquipPositionMap_EquipPositionId",
                table: "ItemEquipPositionMap",
                column: "EquipPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemEquipPositionMap_ItemId",
                table: "ItemEquipPositionMap",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Monster_ElementId",
                table: "Monster",
                column: "ElementId");

            migrationBuilder.CreateIndex(
                name: "IX_Monster_RaceId",
                table: "Monster",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Monster_ScaleId",
                table: "Monster",
                column: "ScaleId");

            migrationBuilder.CreateIndex(
                name: "IX_MonsterItemMap_ItemId",
                table: "MonsterItemMap",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MonsterItemMap_MonsterId",
                table: "MonsterItemMap",
                column: "MonsterId");

            migrationBuilder.CreateIndex(
                name: "IX_MonsterMvpDropMaps_ItemId",
                table: "MonsterMvpDropMaps",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MonsterMvpDropMaps_MonsterId",
                table: "MonsterMvpDropMaps",
                column: "MonsterId");

            migrationBuilder.CreateIndex(
                name: "IX_MonsterPerLocationMap_LocationId",
                table: "MonsterPerLocationMap",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_MonsterPerLocationMap_MonsterId",
                table: "MonsterPerLocationMap",
                column: "MonsterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemEquipPositionMap");

            migrationBuilder.DropTable(
                name: "MonsterItemMap");

            migrationBuilder.DropTable(
                name: "MonsterMvpDropMaps");

            migrationBuilder.DropTable(
                name: "MonsterPerLocationMap");

            migrationBuilder.DropTable(
                name: "EquipPosition");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Monster");

            migrationBuilder.DropTable(
                name: "ItemType");

            migrationBuilder.DropTable(
                name: "SubType");

            migrationBuilder.DropTable(
                name: "Element");

            migrationBuilder.DropTable(
                name: "Race");

            migrationBuilder.DropTable(
                name: "Scales");
        }
    }
}
