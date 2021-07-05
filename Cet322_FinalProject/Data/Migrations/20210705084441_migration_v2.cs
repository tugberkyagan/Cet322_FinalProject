﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Cet322_FinalProject.Data.Migrations
{
    public partial class migration_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Todo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isComplete = table.Column<bool>(type: "bit", nullable: false),
                    isHundread = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Todo_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubTodo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DependedTodoId = table.Column<int>(type: "int", nullable: true),
                    isComplete = table.Column<bool>(type: "bit", nullable: false),
                    EffectRateOnTodo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubTodo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubTodo_Todo_DependedTodoId",
                        column: x => x.DependedTodoId,
                        principalTable: "Todo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubTodo_DependedTodoId",
                table: "SubTodo",
                column: "DependedTodoId");

            migrationBuilder.CreateIndex(
                name: "IX_Todo_CategoryId",
                table: "Todo",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubTodo");

            migrationBuilder.DropTable(
                name: "Todo");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
