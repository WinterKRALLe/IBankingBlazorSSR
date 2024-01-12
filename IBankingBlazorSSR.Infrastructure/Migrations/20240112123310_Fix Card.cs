using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IBankingBlazorSSR.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixCard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_AspNetUsers_ApplicationUserId",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_ApplicationUserId",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Cards");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationUserId",
                table: "Cards",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cards_ApplicationUserId",
                table: "Cards",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_AspNetUsers_ApplicationUserId",
                table: "Cards",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
