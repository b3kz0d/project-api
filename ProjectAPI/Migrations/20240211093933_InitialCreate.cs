using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "projet",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    _date = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    horaires = table.Column<string>(type: "text", nullable: true),
                    travail = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    meteo = table.Column<string>(type: "text", nullable: true),
                    temp1 = table.Column<int>(type: "integer", nullable: true),
                    temp2 = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("projet_pk", x => x.uuid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "projet");
        }
    }
}
