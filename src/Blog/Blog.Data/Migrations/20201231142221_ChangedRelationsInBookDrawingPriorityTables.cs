using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Data.Migrations
{
    public partial class ChangedRelationsInBookDrawingPriorityTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookTag_Books_BookId",
                table: "BookTag");

            migrationBuilder.DropForeignKey(
                name: "FK_DrawingTag_Drawings_DrawingId",
                table: "DrawingTag");

            migrationBuilder.DropIndex(
                name: "IX_DrawingTag_DrawingId",
                table: "DrawingTag");

            migrationBuilder.DropIndex(
                name: "IX_BookTag_BookId",
                table: "BookTag");

            migrationBuilder.DropColumn(
                name: "DrawingId",
                table: "DrawingTag");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "BookTag");

            migrationBuilder.CreateTable(
                name: "BookBookTag",
                columns: table => new
                {
                    BookTagsId = table.Column<int>(type: "int", nullable: false),
                    BooksId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookBookTag", x => new { x.BookTagsId, x.BooksId });
                    table.ForeignKey(
                        name: "FK_BookBookTag_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookBookTag_BookTag_BookTagsId",
                        column: x => x.BookTagsId,
                        principalTable: "BookTag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DrawingDrawingTag",
                columns: table => new
                {
                    DrawingTagsId = table.Column<int>(type: "int", nullable: false),
                    DrawingsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrawingDrawingTag", x => new { x.DrawingTagsId, x.DrawingsId });
                    table.ForeignKey(
                        name: "FK_DrawingDrawingTag_Drawings_DrawingsId",
                        column: x => x.DrawingsId,
                        principalTable: "Drawings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrawingDrawingTag_DrawingTag_DrawingTagsId",
                        column: x => x.DrawingTagsId,
                        principalTable: "DrawingTag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookBookTag_BooksId",
                table: "BookBookTag",
                column: "BooksId");

            migrationBuilder.CreateIndex(
                name: "IX_DrawingDrawingTag_DrawingsId",
                table: "DrawingDrawingTag",
                column: "DrawingsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookBookTag");

            migrationBuilder.DropTable(
                name: "DrawingDrawingTag");

            migrationBuilder.AddColumn<Guid>(
                name: "DrawingId",
                table: "DrawingTag",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BookId",
                table: "BookTag",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DrawingTag_DrawingId",
                table: "DrawingTag",
                column: "DrawingId");

            migrationBuilder.CreateIndex(
                name: "IX_BookTag_BookId",
                table: "BookTag",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookTag_Books_BookId",
                table: "BookTag",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DrawingTag_Drawings_DrawingId",
                table: "DrawingTag",
                column: "DrawingId",
                principalTable: "Drawings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
