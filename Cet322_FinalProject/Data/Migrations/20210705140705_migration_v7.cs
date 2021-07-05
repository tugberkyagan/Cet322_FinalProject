using Microsoft.EntityFrameworkCore.Migrations;

namespace Cet322_FinalProject.Data.Migrations
{
    public partial class migration_v7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isHundread",
                table: "Todo");

            migrationBuilder.DropColumn(
                name: "EffectRateOnTodo",
                table: "SubTodo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "isHundread",
                table: "Todo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EffectRateOnTodo",
                table: "SubTodo",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
