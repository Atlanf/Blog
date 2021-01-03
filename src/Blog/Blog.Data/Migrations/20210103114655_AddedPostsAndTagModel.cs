using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Data.Migrations
{
    public partial class AddedPostsAndTagModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookBookTag_BookTag_BookTagsId",
                table: "BookBookTag");

            migrationBuilder.DropForeignKey(
                name: "FK_DrawingDrawingTag_DrawingTag_DrawingTagsId",
                table: "DrawingDrawingTag");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTasks_UserTaskPriority_PriorityId",
                table: "UserTasks");

            migrationBuilder.DropTable(
                name: "BookTag");

            migrationBuilder.DropTable(
                name: "DrawingTag");

            migrationBuilder.DropTable(
                name: "UserTaskPriority");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpectedFinish",
                table: "UserTasks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UserPostId",
                table: "StoredFiles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BookTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DrawingTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrawingTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatePosted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEdit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Edited = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsPrivate = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPosts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserTaskPriorities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTaskPriorities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostTagUserPost",
                columns: table => new
                {
                    PostTagsId = table.Column<int>(type: "int", nullable: false),
                    PostsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTagUserPost", x => new { x.PostTagsId, x.PostsId });
                    table.ForeignKey(
                        name: "FK_PostTagUserPost_PostTags_PostTagsId",
                        column: x => x.PostTagsId,
                        principalTable: "PostTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostTagUserPost_UserPosts_PostsId",
                        column: x => x.PostsId,
                        principalTable: "UserPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BookTags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 0, "Adventure" },
                    { 1, "Art" },
                    { 2, "Fantasy" },
                    { 3, "Mystery" },
                    { 4, "SciFi" },
                    { 5, "Science" }
                });

            migrationBuilder.InsertData(
                table: "DrawingTags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 8, "Dropped" },
                    { 7, "Finished" },
                    { 5, "Building" },
                    { 4, "Objects" },
                    { 6, "Other" },
                    { 2, "Landscape" },
                    { 1, "Line" },
                    { 0, "Practice" },
                    { 3, "Character" }
                });

            migrationBuilder.InsertData(
                table: "PostTags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 0, "Note" },
                    { 1, "Technology" },
                    { 2, "Art" },
                    { 3, "Development" },
                    { 4, "Hardware" },
                    { 5, "Software" },
                    { 6, "Other" }
                });

            migrationBuilder.InsertData(
                table: "UserTaskPriorities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 2, "Medium" },
                    { 1, "Low" },
                    { 3, "High" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_StoredFiles_UserPostId",
                table: "StoredFiles",
                column: "UserPostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTagUserPost_PostsId",
                table: "PostTagUserPost",
                column: "PostsId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPosts_UserId",
                table: "UserPosts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookBookTag_BookTags_BookTagsId",
                table: "BookBookTag",
                column: "BookTagsId",
                principalTable: "BookTags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DrawingDrawingTag_DrawingTags_DrawingTagsId",
                table: "DrawingDrawingTag",
                column: "DrawingTagsId",
                principalTable: "DrawingTags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StoredFiles_UserPosts_UserPostId",
                table: "StoredFiles",
                column: "UserPostId",
                principalTable: "UserPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTasks_UserTaskPriorities_PriorityId",
                table: "UserTasks",
                column: "PriorityId",
                principalTable: "UserTaskPriorities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookBookTag_BookTags_BookTagsId",
                table: "BookBookTag");

            migrationBuilder.DropForeignKey(
                name: "FK_DrawingDrawingTag_DrawingTags_DrawingTagsId",
                table: "DrawingDrawingTag");

            migrationBuilder.DropForeignKey(
                name: "FK_StoredFiles_UserPosts_UserPostId",
                table: "StoredFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTasks_UserTaskPriorities_PriorityId",
                table: "UserTasks");

            migrationBuilder.DropTable(
                name: "BookTags");

            migrationBuilder.DropTable(
                name: "DrawingTags");

            migrationBuilder.DropTable(
                name: "PostTagUserPost");

            migrationBuilder.DropTable(
                name: "UserTaskPriorities");

            migrationBuilder.DropTable(
                name: "PostTags");

            migrationBuilder.DropTable(
                name: "UserPosts");

            migrationBuilder.DropIndex(
                name: "IX_StoredFiles_UserPostId",
                table: "StoredFiles");

            migrationBuilder.DropColumn(
                name: "ExpectedFinish",
                table: "UserTasks");

            migrationBuilder.DropColumn(
                name: "UserPostId",
                table: "StoredFiles");

            migrationBuilder.CreateTable(
                name: "BookTag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    TagName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookTag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DrawingTag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    TagName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrawingTag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTaskPriority",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PriorityValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTaskPriority", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "BookTag",
                columns: new[] { "Id", "TagName" },
                values: new object[,]
                {
                    { 0, "Adventure" },
                    { 1, "Art" },
                    { 2, "Fantasy" },
                    { 3, "Mystery" },
                    { 4, "SciFi" },
                    { 5, "Science" }
                });

            migrationBuilder.InsertData(
                table: "DrawingTag",
                columns: new[] { "Id", "TagName" },
                values: new object[,]
                {
                    { 8, "Dropped" },
                    { 7, "Finished" },
                    { 6, "Other" },
                    { 5, "Building" },
                    { 2, "Landscape" },
                    { 3, "Character" },
                    { 1, "Line" },
                    { 0, "Practice" },
                    { 4, "Objects" }
                });

            migrationBuilder.InsertData(
                table: "UserTaskPriority",
                columns: new[] { "Id", "PriorityValue" },
                values: new object[,]
                {
                    { 2, "Medium" },
                    { 1, "Low" },
                    { 3, "High" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_BookBookTag_BookTag_BookTagsId",
                table: "BookBookTag",
                column: "BookTagsId",
                principalTable: "BookTag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DrawingDrawingTag_DrawingTag_DrawingTagsId",
                table: "DrawingDrawingTag",
                column: "DrawingTagsId",
                principalTable: "DrawingTag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTasks_UserTaskPriority_PriorityId",
                table: "UserTasks",
                column: "PriorityId",
                principalTable: "UserTaskPriority",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
