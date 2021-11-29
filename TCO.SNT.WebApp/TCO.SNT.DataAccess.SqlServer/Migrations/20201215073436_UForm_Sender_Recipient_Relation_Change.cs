using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class UForm_Sender_Recipient_Relation_Change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UForms_UFormParticipants_RecipientId",
                table: "UForms");

            migrationBuilder.DropForeignKey(
                name: "FK_UForms_UFormParticipants_SenderId",
                table: "UForms");

            migrationBuilder.AlterColumn<int>(
                name: "SenderId",
                table: "UForms",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UForms_UFormParticipants_RecipientId",
                table: "UForms");

            migrationBuilder.DropForeignKey(
                name: "FK_UForms_UFormParticipants_SenderId",
                table: "UForms");

            migrationBuilder.AlterColumn<int>(
                name: "SenderId",
                table: "UForms",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_UForms_UFormParticipants_RecipientId",
                table: "UForms",
                column: "RecipientId",
                principalTable: "UFormParticipants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UForms_UFormParticipants_SenderId",
                table: "UForms",
                column: "SenderId",
                principalTable: "UFormParticipants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
