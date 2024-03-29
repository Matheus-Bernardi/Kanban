﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoccoEmFrente.Kanban.Application.Migrations
{
    public partial class NovaColunaPostit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Postits",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Postits");
        }
    }
}
