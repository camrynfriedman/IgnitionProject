using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAgentPro.Migrations
{
    public partial class InsertedContactInfo_Quote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PolicyHolderEmailAddress",
                table: "Quotes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PolicyHolderPhoneNumber",
                table: "Quotes",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PolicyHolderEmailAddress",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "PolicyHolderPhoneNumber",
                table: "Quotes");
        }
    }
}
