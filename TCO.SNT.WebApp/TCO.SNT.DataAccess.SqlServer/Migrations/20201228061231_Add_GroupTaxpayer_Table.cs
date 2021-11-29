using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class Add_GroupTaxpayer_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroupTaxpayers",
                columns: table => new
                {
                    GroupId = table.Column<Guid>(nullable: false),
                    TaxpayerId = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<Guid>(maxLength: 36, nullable: false),
                    Created = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupTaxpayers", x => new { x.GroupId, x.TaxpayerId });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupTaxpayers");
        }
    }
}
