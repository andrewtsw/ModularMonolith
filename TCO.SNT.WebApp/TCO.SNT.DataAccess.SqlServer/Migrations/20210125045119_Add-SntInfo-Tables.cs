using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class AddSntInfoTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SntAcceptanceGoodsInfo",
                columns: table => new
                {
                    SntInfoSntId = table.Column<int>(nullable: false),
                    AcceptanceOrRejectionProducer = table.Column<string>(nullable: false),
                    AcceptanceOrRejectionDate = table.Column<string>(nullable: false),
                    CompanySignature = table.Column<string>(nullable: true),
                    OperatorSignature = table.Column<string>(nullable: true),
                    AcceptanceOrRejectionName = table.Column<string>(nullable: false),
                    PowerOfAttorneyNumber = table.Column<string>(nullable: true),
                    PowerOfAttorneyDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SntAcceptanceGoodsInfo", x => x.SntInfoSntId);
                    table.ForeignKey(
                        name: "FK_SntAcceptanceGoodsInfo_SntInfo_SntInfoSntId",
                        column: x => x.SntInfoSntId,
                        principalTable: "SntInfo",
                        principalColumn: "SntId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SntOgdMarksInfo",
                columns: table => new
                {
                    SntInfoSntId = table.Column<int>(nullable: false),
                    SignDate = table.Column<DateTime>(nullable: false),
                    SntOgdMarksBody = table.Column<string>(nullable: false),
                    SntOgdMarksInfoSignature = table.Column<string>(nullable: false),
                    SntOgdMarksInfoSignatureType = table.Column<int>(nullable: false),
                    SntOgdMarksInfoCertificate = table.Column<string>(nullable: false),
                    SntOgdMarksInfoSignatureValid = table.Column<bool>(nullable: false),
                    OgdEmployeeFullName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SntOgdMarksInfo", x => x.SntInfoSntId);
                    table.ForeignKey(
                        name: "FK_SntOgdMarksInfo_SntInfo_SntInfoSntId",
                        column: x => x.SntInfoSntId,
                        principalTable: "SntInfo",
                        principalColumn: "SntId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SntAcceptanceGoodsInfo");

            migrationBuilder.DropTable(
                name: "SntOgdMarksInfo");
        }
    }
}
