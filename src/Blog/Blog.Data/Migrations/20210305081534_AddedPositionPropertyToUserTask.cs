using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Data.Migrations
{
    public partial class AddedPositionPropertyToUserTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "UserTasks",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "UserTasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<bool>(
                name: "IsHidden",
                table: "UserProjects",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "UserProjects",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "UserProjects",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsPrivate",
                table: "UserPosts",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "UserPosts",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "Edited",
                table: "UserPosts",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "StoredFiles",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<string>(
                name: "FileUniqueName",
                table: "StoredFiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsImage",
                table: "StoredFiles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "BookTags",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Network");

            migrationBuilder.UpdateData(
                table: "BookTags",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "SciFi");

            migrationBuilder.InsertData(
                table: "BookTags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 6, "Science" },
                    { 7, "Software" },
                    { 8, "Web" },
                    { 9, "Other" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookTags",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "BookTags",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "BookTags",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "BookTags",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DropColumn(
                name: "Position",
                table: "UserTasks");

            migrationBuilder.DropColumn(
                name: "FileUniqueName",
                table: "StoredFiles");

            migrationBuilder.DropColumn(
                name: "IsImage",
                table: "StoredFiles");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "UserTasks",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsHidden",
                table: "UserProjects",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "UserProjects",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "UserProjects",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsPrivate",
                table: "UserPosts",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "UserPosts",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "Edited",
                table: "UserPosts",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "StoredFiles",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.UpdateData(
                table: "BookTags",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "SciFi");

            migrationBuilder.UpdateData(
                table: "BookTags",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Science");
        }
    }
}
