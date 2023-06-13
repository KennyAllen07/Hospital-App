using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital_App.Migrations
{
    public partial class hospi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_PostId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Drugs_Carts_CartId",
                table: "Drugs");

            migrationBuilder.DropIndex(
                name: "IX_Drugs_CartId",
                table: "Drugs");

            migrationBuilder.DropIndex(
                name: "IX_Comments_PostId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "Drugs");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Picture",
                keyValue: null,
                column: "Picture",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Picture",
                table: "Users",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "CommentId",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Comments",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "AddToCart",
                table: "Carts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DrugId",
                table: "Carts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsPaid",
                table: "Carts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Carts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ReferenceId",
                table: "Carts",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CommentId",
                table: "Posts",
                column: "CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Comments_CommentId",
                table: "Posts",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Comments_CommentId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_CommentId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "AddToCart",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "DrugId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "IsPaid",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "ReferenceId",
                table: "Carts");

            migrationBuilder.AlterColumn<string>(
                name: "Picture",
                table: "Users",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "Drugs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Drugs_CartId",
                table: "Drugs",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_PostId",
                table: "Comments",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Drugs_Carts_CartId",
                table: "Drugs",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id");
        }
    }
}
