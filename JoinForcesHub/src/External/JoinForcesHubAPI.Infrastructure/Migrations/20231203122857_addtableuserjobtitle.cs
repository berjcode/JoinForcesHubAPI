using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JoinForcesHubAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addtableuserjobtitle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserJobTitle",
                table: "Users",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserJobTitle",
                table: "Users");
        }
    }
}
