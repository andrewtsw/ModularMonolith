using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class CreateUFormInfoTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from UFormProducts");
            migrationBuilder.Sql("delete from UForms");
            migrationBuilder.Sql("delete from UFormParticipants");

            migrationBuilder.Sql("update Settings set UFormUpdatesLastUFormId = 0, UFormUpdatesLastEventDateUtc = '2019-01-01'");

            migrationBuilder.DropColumn(
                name: "CancelReason",
                table: "UForms");

            migrationBuilder.DropColumn(
                name: "CreatorLogin",
                table: "UForms");

            migrationBuilder.DropColumn(
                name: "InputDateUtc",
                table: "UForms");

            migrationBuilder.DropColumn(
                name: "LastUpdateDateUtc",
                table: "UForms");

            migrationBuilder.DropColumn(
                name: "RegistrationNumber",
                table: "UForms");

            migrationBuilder.DropColumn(
                name: "Signature",
                table: "UForms");

            migrationBuilder.DropColumn(
                name: "SignatureType",
                table: "UForms");

            migrationBuilder.DropColumn(
                name: "SignatureValid",
                table: "UForms");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "UForms");

            migrationBuilder.DropColumn(
                name: "UFormBody",
                table: "UForms");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "UForms");

            migrationBuilder.CreateTable(
                name: "UFormInfo",
                columns: table => new
                {
                    UFormId = table.Column<int>(nullable: false),
                    UFormBody = table.Column<string>(nullable: true),
                    InputDateUtc = table.Column<DateTimeOffset>(nullable: true),
                    LastUpdateDateUtc = table.Column<DateTimeOffset>(nullable: true),
                    SignatureValid = table.Column<bool>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CancelReason = table.Column<string>(nullable: true),
                    Version = table.Column<string>(nullable: false),
                    Signature = table.Column<string>(nullable: true),
                    SignatureType = table.Column<int>(nullable: true),
                    RegistrationNumber = table.Column<string>(nullable: true),
                    CreatorLogin = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UFormInfo", x => x.UFormId);
                    table.ForeignKey(
                        name: "FK_UFormInfo_UForms_UFormId",
                        column: x => x.UFormId,
                        principalTable: "UForms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UFormInfo");

            migrationBuilder.AddColumn<string>(
                name: "CancelReason",
                table: "UForms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatorLogin",
                table: "UForms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "InputDateUtc",
                table: "UForms",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastUpdateDateUtc",
                table: "UForms",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegistrationNumber",
                table: "UForms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Signature",
                table: "UForms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SignatureType",
                table: "UForms",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SignatureValid",
                table: "UForms",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "UForms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UFormBody",
                table: "UForms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Version",
                table: "UForms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
