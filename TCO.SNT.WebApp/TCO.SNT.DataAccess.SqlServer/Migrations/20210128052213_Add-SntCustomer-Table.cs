using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class AddSntCustomerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SntCustomer",
                columns: table => new
                {
                    SntId = table.Column<int>(nullable: false),
                    ActualAddress = table.Column<string>(nullable: true),
                    CountryCode = table.Column<string>(nullable: false),
                    NonResident = table.Column<bool>(nullable: true),
                    RegisterCountryCode = table.Column<string>(nullable: false),
                    ReorganizedTin = table.Column<string>(nullable: true),
                    Statuses = table.Column<string>(nullable: true),
                    ExternalStoreId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SntCustomer", x => x.SntId);
                    table.ForeignKey(
                        name: "FK_SntCustomer_Snts_SntId",
                        column: x => x.SntId,
                        principalTable: "Snts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SntCustomer");
        }
    }
}
