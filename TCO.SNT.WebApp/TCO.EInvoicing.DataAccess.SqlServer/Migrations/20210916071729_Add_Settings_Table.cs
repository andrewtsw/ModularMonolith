using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.EInvoicing.DataAccess.SqlServer.Migrations
{
    public partial class Add_Settings_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ei");

            migrationBuilder.CreateTable(
                name: "Settings",
                schema: "ei",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoicesUpdatesInboundLastEventDateUtc = table.Column<DateTimeOffset>(nullable: false),
                    InvoicesUpdatesInboundLastInvoiceId = table.Column<long>(nullable: false),
                    InvoicesUpdatesOutboundLastEventDateUtc = table.Column<DateTimeOffset>(nullable: false),
                    InvoicesUpdatesOutboundLastInvoiceId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "ei",
                table: "Settings",
                columns: new[] { "Id", "InvoicesUpdatesInboundLastEventDateUtc", "InvoicesUpdatesInboundLastInvoiceId", "InvoicesUpdatesOutboundLastEventDateUtc", "InvoicesUpdatesOutboundLastInvoiceId" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0L, new DateTimeOffset(new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings",
                schema: "ei");
        }
    }
}
