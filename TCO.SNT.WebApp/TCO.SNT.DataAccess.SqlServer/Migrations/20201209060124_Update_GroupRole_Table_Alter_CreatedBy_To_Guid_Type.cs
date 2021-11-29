using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class Update_GroupRole_Table_Alter_CreatedBy_To_Guid_Type : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [GroupRoles]", true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedBy",
                table: "GroupRoles",
                maxLength: 36,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(36)",
                oldMaxLength: 36);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [GroupRoles]", true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "GroupRoles",
                type: "nvarchar(36)",
                maxLength: 36,
                nullable: false,
                oldClrType: typeof(Guid),
                oldMaxLength: 36);
        }
    }
}
