using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class RemoveSntTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Snts");

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UFormUpdatesLastEventDateUtc",
                value: new DateTimeOffset(new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Snts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CancelReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Certificate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatorLogin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatorTin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExternalId = table.Column<long>(type: "bigint", nullable: false),
                    InputDateUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdateDateUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenderSignerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Signature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SignatureType = table.Column<int>(type: "int", nullable: false),
                    SignatureValid = table.Column<bool>(type: "bit", nullable: false),
                    SntBody = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Snts", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UFormUpdatesLastEventDateUtc",
                value: new DateTimeOffset(new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.CreateIndex(
                name: "IX_Snts_ExternalId",
                table: "Snts",
                column: "ExternalId",
                unique: true);
        }
    }
}
