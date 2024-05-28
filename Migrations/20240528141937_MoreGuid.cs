using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnet_asp_todo.Migrations
{
    /// <inheritdoc />
    public partial class MoreGuid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ScopedGuid2",
                table: "Todos",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SingletonGuid2",
                table: "Todos",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TransientGuid2",
                table: "Todos",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScopedGuid2",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "SingletonGuid2",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "TransientGuid2",
                table: "Todos");
        }
    }
}
