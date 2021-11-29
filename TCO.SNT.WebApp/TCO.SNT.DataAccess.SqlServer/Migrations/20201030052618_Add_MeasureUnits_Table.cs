using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class Add_MeasureUnits_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MeasureUnits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(maxLength: 16, nullable: false),
                    CodeMkei = table.Column<string>(maxLength: 16, nullable: false),
                    CodeOkei = table.Column<string>(maxLength: 16, nullable: false),
                    CodeTis = table.Column<string>(maxLength: 16, nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: true),
                    NameKz = table.Column<string>(maxLength: 400, nullable: false),
                    NameRu = table.Column<string>(maxLength: 400, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasureUnits", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MeasureUnits_Code",
                table: "MeasureUnits",
                column: "Code",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeasureUnits");
        }
    }
}
