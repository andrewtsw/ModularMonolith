using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class Update_GroupRole_Table_Remove_Id_Column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupRoles",
                table: "GroupRoles");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "GroupRoles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupRoles",
                table: "GroupRoles",
                columns: new[] { "GroupId", "Role" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupRoles",
                table: "GroupRoles");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "GroupRoles",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupRoles",
                table: "GroupRoles",
                column: "Id");
        }
    }
}
