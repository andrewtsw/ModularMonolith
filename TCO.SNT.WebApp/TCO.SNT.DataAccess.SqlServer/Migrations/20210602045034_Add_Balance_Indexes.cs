using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class Add_Balance_Indexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("update Balances set Name = LEFT(Name, 450) where LEN(Name) > 450");

            migrationBuilder.AlterColumn<string>(
                name: "TnvedCode",
                table: "Balances",
                maxLength: 450,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Balances",
                maxLength: 450,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "KpvedCode",
                table: "Balances",
                maxLength: 450,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "GtinCode",
                table: "Balances",
                maxLength: 450,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Balances_GtinCode",
                table: "Balances",
                column: "GtinCode");

            migrationBuilder.CreateIndex(
                name: "IX_Balances_KpvedCode",
                table: "Balances",
                column: "KpvedCode");

            migrationBuilder.CreateIndex(
                name: "IX_Balances_Name",
                table: "Balances",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Balances_ProductId",
                table: "Balances",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Balances_Quantity",
                table: "Balances",
                column: "Quantity");

            migrationBuilder.CreateIndex(
                name: "IX_Balances_ReserveQuantity",
                table: "Balances",
                column: "ReserveQuantity");

            migrationBuilder.CreateIndex(
                name: "IX_Balances_TnvedCode",
                table: "Balances",
                column: "TnvedCode");

            migrationBuilder.CreateIndex(
                name: "IX_Balances_UnitPrice",
                table: "Balances",
                column: "UnitPrice");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Balances_GtinCode",
                table: "Balances");

            migrationBuilder.DropIndex(
                name: "IX_Balances_KpvedCode",
                table: "Balances");

            migrationBuilder.DropIndex(
                name: "IX_Balances_Name",
                table: "Balances");

            migrationBuilder.DropIndex(
                name: "IX_Balances_ProductId",
                table: "Balances");

            migrationBuilder.DropIndex(
                name: "IX_Balances_Quantity",
                table: "Balances");

            migrationBuilder.DropIndex(
                name: "IX_Balances_ReserveQuantity",
                table: "Balances");

            migrationBuilder.DropIndex(
                name: "IX_Balances_TnvedCode",
                table: "Balances");

            migrationBuilder.DropIndex(
                name: "IX_Balances_UnitPrice",
                table: "Balances");

            migrationBuilder.AlterColumn<string>(
                name: "TnvedCode",
                table: "Balances",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 450);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Balances",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 450);

            migrationBuilder.AlterColumn<string>(
                name: "KpvedCode",
                table: "Balances",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 450);

            migrationBuilder.AlterColumn<string>(
                name: "GtinCode",
                table: "Balances",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 450,
                oldNullable: true);
        }
    }
}
