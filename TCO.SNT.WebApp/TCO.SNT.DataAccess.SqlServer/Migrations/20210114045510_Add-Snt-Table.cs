using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class AddSntTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Snts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExternalId = table.Column<long>(nullable: false),
                    InputDateUtc = table.Column<DateTimeOffset>(nullable: false),
                    LastUpdateDateUtc = table.Column<DateTimeOffset>(nullable: false),
                    RegistrationNumber = table.Column<string>(nullable: false),
                    Version = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    SntBody = table.Column<string>(nullable: false),
                    CreatorLogin = table.Column<string>(nullable: false),
                    CreatorTin = table.Column<string>(nullable: false),
                    SenderSignerName = table.Column<string>(nullable: false),
                    Signature = table.Column<string>(nullable: false),
                    SignatureType = table.Column<int>(nullable: false),
                    Certificate = table.Column<string>(nullable: false),
                    SignatureValid = table.Column<bool>(nullable: false),
                    CancelReason = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Snts", x => x.Id);
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
                name: "Snts");
        }
    }
}
