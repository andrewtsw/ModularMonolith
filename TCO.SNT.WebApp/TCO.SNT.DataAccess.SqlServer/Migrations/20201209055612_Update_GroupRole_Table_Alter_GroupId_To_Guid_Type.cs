using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class Update_GroupRole_Table_Alter_GroupId_To_Guid_Type : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [GroupRoles]", true);

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupRoles",
                table: "GroupRoles");

            migrationBuilder.AlterColumn<Guid>(
               name: "GroupId",
               table: "GroupRoles",
               maxLength: 36,
               nullable: false,
               oldClrType: typeof(string),
               oldType: "nvarchar(36)",
               oldMaxLength: 36);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupRoles",
                table: "GroupRoles",
                columns: new[] { "GroupId", "Role" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [GroupRoles]", true);

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupRoles",
                table: "GroupRoles");

            migrationBuilder.AlterColumn<string>(
                name: "GroupId",
                table: "GroupRoles",
                type: "nvarchar(36)",
                maxLength: 36,
                nullable: false,
                oldClrType: typeof(Guid),
                oldMaxLength: 36);

            migrationBuilder.AddPrimaryKey(
            name: "PK_GroupRoles",
            table: "GroupRoles",
            columns: new[] { "GroupId", "Role" });
        }
    }
}
