using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.Finportal.Shared.DataAccess.SqlServer.Migrations
{
    public partial class SharedModule_Move_MeasureUnits_To_Shared_Module : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER SCHEMA shared TRANSFER [dbo].[MeasureUnits]");
            migrationBuilder.Sql("ALTER SCHEMA shared TRANSFER [dbo].[FavouriteMeasureUnits]");

            migrationBuilder.CreateTable(
                name: "Settings",
                schema: "shared",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeasureUnitsLastEventDateUtc = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "shared",
                table: "Settings",
                columns: new[] { "Id", "MeasureUnitsLastEventDateUtc" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
