using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class Change_EsfUserProfile_UserId_Type_To_Guid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from [EsfUserProfiles]");

            migrationBuilder.Sql("ALTER TABLE EsfUserProfiles DROP constraint [PK_EsfUserProfiles]");

            migrationBuilder.Sql("ALTER TABLE [EsfUserProfiles] ALTER COLUMN [UserId] uniqueidentifier NOT NULL");
            
            migrationBuilder.Sql(@"ALTER TABLE EsfUserProfiles ADD constraint [PK_EsfUserProfiles] PRIMARY KEY CLUSTERED 
                (
                    [UserId] ASC
                )");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "EsfUserProfiles",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            throw new NotImplementedException();
        }
    }
}
