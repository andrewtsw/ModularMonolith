using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class Update_AuditableFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
            name: "CreatedBy",
            table: "GroupTaxpayerStores",
            nullable: false,
            oldClrType: typeof(Guid),
            oldType: "uniqueidentifier");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
            name: "CreatedBy",
            table: "GroupTaxpayerStores",
            nullable: false,
            oldClrType: typeof(Guid),
            oldType: "uniqueidentifier",
            maxLength: 36);
        }
    }
}
