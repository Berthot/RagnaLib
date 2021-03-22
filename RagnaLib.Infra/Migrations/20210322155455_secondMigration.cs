using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace RagnaLib.Infra.Migrations
{
    public partial class secondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Race",
                table: "Monster",
                newName: "RaceId");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "SubType",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DbName",
                table: "Monster",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Attack",
                table: "Item",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CardPrefix",
                table: "Item",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Defense",
                table: "Item",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ItemLevel",
                table: "Item",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LimitLevel",
                table: "Item",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MagicAttack",
                table: "Item",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Refinable",
                table: "Item",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "RequiredLevel",
                table: "Item",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Slots",
                table: "Item",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UnidName",
                table: "Item",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "Item",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.InsertData(
                table: "EquipPosition",
                columns: new[] { "Id", "Description", "Position" },
                values: new object[,]
                {
                    { -1, null, "Unknown" },
                    { 23, null, "Weapon" },
                    { 22, null, "Upper Costume Headgear" },
                    { 21, null, "Shoes" },
                    { 20, null, "Shield" },
                    { 19, null, "Shadow Weapon" },
                    { 18, null, "Shadow Shoes" },
                    { 17, null, "Shadow Shield" },
                    { 16, null, "Shadow Armor" },
                    { 15, null, "Shadow Accessory (Right)" },
                    { 14, null, "Shadow Accessory (Left)" },
                    { 12, null, "Middle Headgear" },
                    { 13, null, "Right Hand" },
                    { 10, null, "Headgear" },
                    { 9, null, "Garment" },
                    { 8, null, "Essence" },
                    { 7, null, "Enchant" },
                    { 6, null, "Costume Garment" },
                    { 5, null, "Both hand" },
                    { 4, null, "Body" },
                    { 3, null, "Armor" },
                    { 2, null, "Accessory (Right)" },
                    { 1, null, "Accessory (Left)" },
                    { 11, null, "Left Hand" }
                });

            migrationBuilder.UpdateData(
                table: "ItemType",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Weapon");

            migrationBuilder.UpdateData(
                table: "ItemType",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Consumable");

            migrationBuilder.UpdateData(
                table: "ItemType",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Etc.");

            migrationBuilder.UpdateData(
                table: "ItemType",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Cash");

            migrationBuilder.UpdateData(
                table: "ItemType",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Costume");

            migrationBuilder.InsertData(
                table: "ItemType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 9, "Card" },
                    { -1, "Unknown" }
                });

            migrationBuilder.InsertData(
                table: "Race",
                columns: new[] { "Id", "EnName", "Name" },
                values: new object[,]
                {
                    { 4, "demon", "demônio" },
                    { 2, "angel", "anjo" },
                    { 3, "brute", "bruto" },
                    { 12, "null", "humano" },
                    { 11, "null", "doram" },
                    { 1, "formless", "amorfo" },
                    { 9, "fish", "peixe" },
                    { 8, "undead", "morto-vivo" },
                    { 7, "insect", "inseto" },
                    { 6, "human", "humanoide" },
                    { 5, "dragon", "dragão" },
                    { 10, "plant", "planta" }
                });

            migrationBuilder.InsertData(
                table: "SubType",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { 36, "-", "-" },
                    { 29, "-", "Special" },
                    { 30, "-", "Regeneration" },
                    { 31, "-", "Taming item" },
                    { 32, "-", "Arrow" },
                    { 33, "-", "Cannonball" },
                    { 34, "-", "Throw Weapon" },
                    { 35, "-", "Ammo" },
                    { 37, "-", "Pistol" },
                    { 43, "Shadow Shield", "Shadow Shield" },
                    { 39, "Left Hand", "Shield" },
                    { 40, "Costume Garment", "Costume Garment" },
                    { 41, "Shadow Weapon", "Shadow Weapon" },
                    { 42, "Shadow Armor", "Shadow Armor" },
                    { 28, "-", "Pet" },
                    { 44, "Shadow Shoes", "Shadow Shoes" },
                    { 45, "Right Shadow Accessory", "Shadow Acc. (Right)" },
                    { 46, "Left Shadow Accessory", "Shadow Acc. (Left)" },
                    { 47, "Upper Costume Headgear", "Costume Helm" },
                    { 38, "-", "Rifle" },
                    { 27, "Shoes", "Shoes" },
                    { 21, "Accessory", "Accessory" },
                    { 25, "Body", "Armor" },
                    { -1, "-", "Unknown" },
                    { 1, "Right Hand", "Dagger" },
                    { 2, "Right Hand", "Sword" },
                    { 3, "Both hand", "Two-handed Sword" },
                    { 4, "Right Hand", "Spear" },
                    { 5, "Both hand", "Two-handed Spear" },
                    { 6, "Right Hand", "Axe" },
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
                    { 22, "Accessory", "Accessory (Right)" },
                    { 23, "Accessory", "Accessory (Left)" },
                    { 24, "Middle Headgear", "Helm" },
                    { 26, "Garment", "Garment" },
                    { 7, "Both hand", "Two-handed Axe" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Monster_RaceId",
                table: "Monster",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemEquipPositionMap_EquipPositionId",
                table: "ItemEquipPositionMap",
                column: "EquipPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemEquipPositionMap_ItemId",
                table: "ItemEquipPositionMap",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_MONSTER_RACE",
                table: "Monster",
                column: "RaceId",
                principalTable: "Race",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MONSTER_RACE",
                table: "Monster");

            migrationBuilder.DropTable(
                name: "ItemEquipPositionMap");

            migrationBuilder.DropTable(
                name: "Race");

            migrationBuilder.DropTable(
                name: "EquipPosition");

            migrationBuilder.DropIndex(
                name: "IX_Monster_RaceId",
                table: "Monster");

            migrationBuilder.DeleteData(
                table: "ItemType",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "ItemType",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "SubType",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "SubType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SubType",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SubType",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SubType",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SubType",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SubType",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SubType",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "SubType",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "SubType",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "SubType",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "SubType",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "SubType",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "SubType",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "SubType",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "SubType",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "SubType",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "SubType",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "SubType",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "SubType",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "SubType",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "SubType",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "SubType",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "SubType",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "SubType",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "SubType",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "SubType",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "SubType",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "SubType",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "SubType",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "SubType",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "SubType",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "SubType",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "SubType",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "SubType",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "SubType",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "SubType",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "SubType",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "SubType",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "SubType",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "SubType",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "SubType",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "SubType",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "SubType",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "SubType",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "SubType",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "SubType",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "SubType",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DropColumn(
                name: "Location",
                table: "SubType");

            migrationBuilder.DropColumn(
                name: "DbName",
                table: "Monster");

            migrationBuilder.DropColumn(
                name: "Attack",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "CardPrefix",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Defense",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "ItemLevel",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "LimitLevel",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "MagicAttack",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Refinable",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "RequiredLevel",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Slots",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "UnidName",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Item");

            migrationBuilder.RenameColumn(
                name: "RaceId",
                table: "Monster",
                newName: "Race");

            migrationBuilder.UpdateData(
                table: "ItemType",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Consumable");

            migrationBuilder.UpdateData(
                table: "ItemType",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Weapon");

            migrationBuilder.UpdateData(
                table: "ItemType",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Card");

            migrationBuilder.UpdateData(
                table: "ItemType",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Costume");

            migrationBuilder.UpdateData(
                table: "ItemType",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Other");
        }
    }
}
