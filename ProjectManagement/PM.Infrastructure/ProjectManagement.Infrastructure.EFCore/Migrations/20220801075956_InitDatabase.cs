using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagement.Infrastructure.EFCore.Migrations
{
    public partial class InitDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Position = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Scope = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProvinceId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Position = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Scope = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Weathers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GeneralCondition = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CurrentTemperature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weathers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weathers_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "Id", "CreationDate", "IsDeleted", "Name", "Position", "Scope" },
                values: new object[] { 1, new DateTime(2022, 8, 1, 0, 59, 54, 974, DateTimeKind.Local).AddTicks(4096), false, "تهران", "مرکز", 1500 });

            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "Id", "CreationDate", "IsDeleted", "Name", "Position", "Scope" },
                values: new object[] { 2, new DateTime(2022, 8, 1, 0, 59, 54, 974, DateTimeKind.Local).AddTicks(4240), false, "آذربایجان غربی", "شمال غرب", 2200 });

            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "Id", "CreationDate", "IsDeleted", "Name", "Position", "Scope" },
                values: new object[] { 3, new DateTime(2022, 8, 1, 0, 59, 54, 974, DateTimeKind.Local).AddTicks(4251), false, "آذربایجان شرقی", "شمال غرب", 1900 });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CreationDate", "IsDeleted", "Name", "Position", "ProvinceId", "Scope" },
                values: new object[] { 1, new DateTime(2022, 8, 1, 0, 59, 54, 974, DateTimeKind.Local).AddTicks(4705), false, "تهران", "مرکز", 1, 270 });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CreationDate", "IsDeleted", "Name", "Position", "ProvinceId", "Scope" },
                values: new object[] { 2, new DateTime(2022, 8, 1, 0, 59, 54, 974, DateTimeKind.Local).AddTicks(4725), false, "ارومیه", "شمال غرب", 2, 65 });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CreationDate", "IsDeleted", "Name", "Position", "ProvinceId", "Scope" },
                values: new object[] { 3, new DateTime(2022, 8, 1, 0, 59, 54, 974, DateTimeKind.Local).AddTicks(4728), false, "تبریز", "شمال غرب", 3, 145 });

            migrationBuilder.InsertData(
                table: "Weathers",
                columns: new[] { "Id", "CityId", "CreationDate", "CurrentTemperature", "GeneralCondition", "IsDeleted" },
                values: new object[] { 1, 1, new DateTime(2022, 8, 1, 0, 59, 54, 974, DateTimeKind.Local).AddTicks(4514), "+32", "گرم خشک", false });

            migrationBuilder.InsertData(
                table: "Weathers",
                columns: new[] { "Id", "CityId", "CreationDate", "CurrentTemperature", "GeneralCondition", "IsDeleted" },
                values: new object[] { 2, 2, new DateTime(2022, 8, 1, 0, 59, 54, 974, DateTimeKind.Local).AddTicks(4526), "+22", "گرم مرطوب", false });

            migrationBuilder.InsertData(
                table: "Weathers",
                columns: new[] { "Id", "CityId", "CreationDate", "CurrentTemperature", "GeneralCondition", "IsDeleted" },
                values: new object[] { 3, 3, new DateTime(2022, 8, 1, 0, 59, 54, 974, DateTimeKind.Local).AddTicks(4534), "+21", "گرم مرطوب", false });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_ProvinceId",
                table: "Cities",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Weathers_CityId",
                table: "Weathers",
                column: "CityId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Weathers");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Provinces");
        }
    }
}
