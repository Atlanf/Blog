using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Data.Migrations
{
    public partial class ChangedPropertyNameInUserTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTasks_UserProjects_UserProjectId",
                table: "UserTasks");

            migrationBuilder.DropIndex(
                name: "IX_UserTasks_UserProjectId",
                table: "UserTasks");

            migrationBuilder.DropColumn(
                name: "UserProjectId",
                table: "UserTasks");

            migrationBuilder.CreateIndex(
                name: "IX_UserTasks_ProjectId",
                table: "UserTasks",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTasks_UserProjects_ProjectId",
                table: "UserTasks",
                column: "ProjectId",
                principalTable: "UserProjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTasks_UserProjects_ProjectId",
                table: "UserTasks");

            migrationBuilder.DropIndex(
                name: "IX_UserTasks_ProjectId",
                table: "UserTasks");

            migrationBuilder.AddColumn<int>(
                name: "UserProjectId",
                table: "UserTasks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserTasks_UserProjectId",
                table: "UserTasks",
                column: "UserProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTasks_UserProjects_UserProjectId",
                table: "UserTasks",
                column: "UserProjectId",
                principalTable: "UserProjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
