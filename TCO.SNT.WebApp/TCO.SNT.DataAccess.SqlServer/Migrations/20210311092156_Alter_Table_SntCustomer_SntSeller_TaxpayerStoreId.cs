using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class Alter_Table_SntCustomer_SntSeller_TaxpayerStoreId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TaxpayerStoreId",
                table: "SntSellers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TaxpayerStoreId",
                table: "SntCustomers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaxpayerStoreId",
                table: "SntSellers");

            migrationBuilder.DropColumn(
                name: "TaxpayerStoreId",
                table: "SntCustomers");
        }
    }
}
