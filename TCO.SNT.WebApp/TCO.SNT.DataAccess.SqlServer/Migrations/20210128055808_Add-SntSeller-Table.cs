using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class AddSntSellerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BranchTin",
                table: "SntCustomer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "SntCustomer",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tin",
                table: "SntCustomer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SntSeller",
                columns: table => new
                {
                    SntId = table.Column<int>(nullable: false),
                    BranchTin = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Tin = table.Column<string>(nullable: true),
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
                    table.PrimaryKey("PK_SntSeller", x => x.SntId);
                    table.ForeignKey(
                        name: "FK_SntSeller_Snts_SntId",
                        column: x => x.SntId,
                        principalTable: "Snts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SntSeller");

            migrationBuilder.DropColumn(
                name: "BranchTin",
                table: "SntCustomer");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "SntCustomer");

            migrationBuilder.DropColumn(
                name: "Tin",
                table: "SntCustomer");
        }
    }
}
