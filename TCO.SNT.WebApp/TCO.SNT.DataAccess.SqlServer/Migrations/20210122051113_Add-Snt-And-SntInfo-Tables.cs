using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class AddSntAndSntInfoTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Snts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExternalId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Snts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SntInfo",
                columns: table => new
                {
                    SntId = table.Column<int>(nullable: false),
                    InputDateUtc = table.Column<DateTimeOffset>(nullable: false),
                    LastUpdateDateUtc = table.Column<DateTimeOffset>(nullable: false),
                    RegistrationNumber = table.Column<string>(nullable: true),
                    Version = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CancelReason = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SntInfo", x => x.SntId);
                    table.ForeignKey(
                        name: "FK_SntInfo_Snts_SntId",
                        column: x => x.SntId,
                        principalTable: "Snts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Snts_ExternalId",
                table: "Snts",
                column: "ExternalId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SntInfo");

            migrationBuilder.DropTable(
                name: "Snts");
        }
    }
}
