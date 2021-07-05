using Microsoft.EntityFrameworkCore.Migrations;

namespace Cet322_FinalProject.Data.Migrations
{
    public partial class migration_v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubTodo_Todo_DependedTodoId",
                table: "SubTodo");

            migrationBuilder.DropIndex(
                name: "IX_SubTodo_DependedTodoId",
                table: "SubTodo");

            migrationBuilder.DropColumn(
                name: "DependedTodoId",
                table: "SubTodo");

            migrationBuilder.AddColumn<int>(
                name: "SubTodoId",
                table: "Todo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Todo_SubTodoId",
                table: "Todo",
                column: "SubTodoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Todo_SubTodo_SubTodoId",
                table: "Todo",
                column: "SubTodoId",
                principalTable: "SubTodo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todo_SubTodo_SubTodoId",
                table: "Todo");

            migrationBuilder.DropIndex(
                name: "IX_Todo_SubTodoId",
                table: "Todo");

            migrationBuilder.DropColumn(
                name: "SubTodoId",
                table: "Todo");

            migrationBuilder.AddColumn<int>(
                name: "DependedTodoId",
                table: "SubTodo",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubTodo_DependedTodoId",
                table: "SubTodo",
                column: "DependedTodoId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubTodo_Todo_DependedTodoId",
                table: "SubTodo",
                column: "DependedTodoId",
                principalTable: "Todo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
