using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class SntModule_Move_MeasureUnits_To_Shared_Module : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MeasureUnitsLastEventDateUtc",
                table: "Settings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
