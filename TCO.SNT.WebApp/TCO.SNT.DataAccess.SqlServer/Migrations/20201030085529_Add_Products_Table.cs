using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class Add_Products_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    FixedId = table.Column<long>(nullable: true),
                    FixedParentId = table.Column<long>(nullable: false),
                    GsvsCode = table.Column<string>(nullable: true),
                    GsvsTypeCode = table.Column<int>(nullable: false),
                    ExternalId = table.Column<long>(nullable: true),
                    IsCanSelect = table.Column<bool>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true),
                    IsExcisable = table.Column<bool>(nullable: false),
                    IsTwofoldPurpose = table.Column<bool>(nullable: false),
                    IsUnique = table.Column<bool>(nullable: false),
                    IsUseInVstore = table.Column<bool>(nullable: true),
                    IsWithdrawal = table.Column<bool>(nullable: true),
                    KpvedTypeCode = table.Column<int>(nullable: true),
                    LastUpdateDate = table.Column<DateTime>(nullable: true),
                    NameEn = table.Column<string>(nullable: true),
                    NameKz = table.Column<string>(nullable: true),
                    NameRu = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
