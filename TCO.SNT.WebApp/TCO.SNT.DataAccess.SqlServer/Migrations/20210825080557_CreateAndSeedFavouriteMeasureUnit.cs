using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class CreateAndSeedFavouriteMeasureUnit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FavouriteMeasureUnits",
                columns: table => new
                {
                    MeasureUnitId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouriteMeasureUnits", x => x.MeasureUnitId);
                    table.ForeignKey(
                        name: "FK_FavouriteMeasureUnits_MeasureUnits_MeasureUnitId",
                        column: x => x.MeasureUnitId,
                        principalTable: "MeasureUnits",
                        principalColumn: "Id");
                });
            migrationBuilder.Sql("insert into FavouriteMeasureUnits (MeasureUnitId) select Id from MeasureUnits as m where m.Code in ('839', '778','796','168','006');");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavouriteMeasureUnits");
        }
    }
}
