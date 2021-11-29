using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.EInvoicing.DataAccess.SqlServer.Migrations
{
    public partial class InvoicesModule_Add_MeasureUnit_Link : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.Sql("ALTER SCHEMA dict TRANSFER [dbo].[MeasureUnits]");

            migrationBuilder.AddColumn<int>(
                name: "MeasureUnitId",
                schema: "ei",
                table: "InvoiceProducts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceProducts_MeasureUnitId",
                schema: "ei",
                table: "InvoiceProducts",
                column: "MeasureUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceProducts_MeasureUnits_MeasureUnitId",
                schema: "ei",
                table: "InvoiceProducts",
                column: "MeasureUnitId",
                principalSchema: "shared",
                principalTable: "MeasureUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
