using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class Add_EsfUserProfile_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Balances_TaxpayerStores_TaxpayerStoreId",
                table: "Balances");

            migrationBuilder.CreateTable(
                name: "EsfUserProfiles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    UsernameSecretName = table.Column<string>(nullable: true),
                    PasswordSecretName = table.Column<string>(nullable: true),
                    Base64AuthCertificateSecretName = table.Column<string>(nullable: true),
                    Base64SignCertificateSecretName = table.Column<string>(nullable: true),
                    SignRSAKeyName = table.Column<string>(nullable: true),
                    IsCompleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EsfUserProfiles", x => x.UserId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Balances_TaxpayerStores_TaxpayerStoreId",
                table: "Balances",
                column: "TaxpayerStoreId",
                principalTable: "TaxpayerStores",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Balances_TaxpayerStores_TaxpayerStoreId",
                table: "Balances");

            migrationBuilder.DropTable(
                name: "EsfUserProfiles");

            migrationBuilder.AddForeignKey(
                name: "FK_Balances_TaxpayerStores_TaxpayerStoreId",
                table: "Balances",
                column: "TaxpayerStoreId",
                principalTable: "TaxpayerStores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
