using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class Add_Balance_IsActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Balances",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Balances");
        }
    }
}
