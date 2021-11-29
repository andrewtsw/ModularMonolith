using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class Add_UFormUpdates_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EsfUFormInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UFormBody = table.Column<string>(nullable: false),
                    ExternalId = table.Column<long>(nullable: false),
                    InputDate = table.Column<DateTime>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false),
                    SignatureValid = table.Column<bool>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CancelReason = table.Column<string>(nullable: true),
                    Version = table.Column<string>(nullable: false),
                    Signature = table.Column<string>(nullable: false),
                    SignatureType = table.Column<int>(nullable: false),
                    RegistrationNumber = table.Column<string>(nullable: false),
                    CreatorLogin = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EsfUFormInfos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EsfUFormInfos_ExternalId",
                table: "EsfUFormInfos",
                column: "ExternalId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EsfUFormInfos");
        }
    }
}
