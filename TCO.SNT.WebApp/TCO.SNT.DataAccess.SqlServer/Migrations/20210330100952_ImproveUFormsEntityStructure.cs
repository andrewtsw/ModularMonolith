using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class ImproveUFormsEntityStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UForms_UFormParticipants_RecipientId",
                table: "UForms");

            migrationBuilder.DropForeignKey(
                name: "FK_UForms_UFormParticipants_SenderId",
                table: "UForms");

            migrationBuilder.DropTable(
                name: "UFormParticipants");

            migrationBuilder.DropIndex(
                name: "IX_UForms_RecipientId",
                table: "UForms");

            migrationBuilder.DropIndex(
                name: "IX_UForms_SenderId",
                table: "UForms");

            migrationBuilder.DropColumn(
                name: "RecipientId",
                table: "UForms");

            migrationBuilder.DropColumn(
                name: "SenderId",
                table: "UForms");

            migrationBuilder.CreateTable(
                name: "UFormRecipients",
                columns: table => new
                {
                    UFormId = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    AgentDocDate = table.Column<string>(nullable: true),
                    AgentDocNum = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    ExternalStoreId = table.Column<long>(nullable: false),
                    TaxpayerStoreId = table.Column<int>(nullable: false),
                    StoreName = table.Column<string>(nullable: false),
                    Tin = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UFormRecipients", x => x.UFormId);
                    table.ForeignKey(
                        name: "FK_UFormRecipients_TaxpayerStores_TaxpayerStoreId",
                        column: x => x.TaxpayerStoreId,
                        principalTable: "TaxpayerStores",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UFormRecipients_UForms_UFormId",
                        column: x => x.UFormId,
                        principalTable: "UForms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UFormSenders",
                columns: table => new
                {
                    UFormId = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    AgentDocDate = table.Column<string>(nullable: true),
                    AgentDocNum = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    ExternalStoreId = table.Column<long>(nullable: false),
                    TaxpayerStoreId = table.Column<int>(nullable: false),
                    StoreName = table.Column<string>(nullable: false),
                    Tin = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UFormSenders", x => x.UFormId);
                    table.ForeignKey(
                        name: "FK_UFormSenders_TaxpayerStores_TaxpayerStoreId",
                        column: x => x.TaxpayerStoreId,
                        principalTable: "TaxpayerStores",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UFormSenders_UForms_UFormId",
                        column: x => x.UFormId,
                        principalTable: "UForms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UFormRecipients_TaxpayerStoreId",
                table: "UFormRecipients",
                column: "TaxpayerStoreId");

            migrationBuilder.CreateIndex(
                name: "IX_UFormSenders_TaxpayerStoreId",
                table: "UFormSenders",
                column: "TaxpayerStoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UFormRecipients");

            migrationBuilder.DropTable(
                name: "UFormSenders");

            migrationBuilder.AddColumn<int>(
                name: "RecipientId",
                table: "UForms",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SenderId",
                table: "UForms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UFormParticipants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgentDocDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgentDocNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExternalStoreId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StoreName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxpayerStoreId = table.Column<int>(type: "int", nullable: false),
                    Tin = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UFormParticipants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UFormParticipants_TaxpayerStores_TaxpayerStoreId",
                        column: x => x.TaxpayerStoreId,
                        principalTable: "TaxpayerStores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UForms_RecipientId",
                table: "UForms",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_UForms_SenderId",
                table: "UForms",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_UFormParticipants_TaxpayerStoreId",
                table: "UFormParticipants",
                column: "TaxpayerStoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_UForms_UFormParticipants_RecipientId",
                table: "UForms",
                column: "RecipientId",
                principalTable: "UFormParticipants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UForms_UFormParticipants_SenderId",
                table: "UForms",
                column: "SenderId",
                principalTable: "UFormParticipants",
                principalColumn: "Id");
        }
    }
}
