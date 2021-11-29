using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.Finportal.Shared.DataAccess.SqlServer.Migrations
{
    public partial class Move_GroupRoles_Table_to_Shared_Module : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER SCHEMA shared TRANSFER [dbo].[GroupRoles]");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER SCHEMA dbo TRANSFER [shared].[GroupRoles]");
        }
    }
}
