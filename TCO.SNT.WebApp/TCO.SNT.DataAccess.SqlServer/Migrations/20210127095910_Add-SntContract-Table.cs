using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class AddSntContractTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SntContract",
                columns: table => new
                {
                    SntId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: true),
                    DeliveryCondition = table.Column<string>(nullable: true),
                    IsContract = table.Column<bool>(nullable: false),
                    Number = table.Column<string>(nullable: true),
                    TermOfContractPayment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SntContract", x => x.SntId);
                    table.ForeignKey(
                        name: "FK_SntContract_Snts_SntId",
                        column: x => x.SntId,
                        principalTable: "Snts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SntContract");
        }
    }
}
