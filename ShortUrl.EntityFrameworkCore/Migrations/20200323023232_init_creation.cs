using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShortUrl.EntityFrameworkCore.Migrations
{
    public partial class init_creation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShortUrlMaps",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShortId = table.Column<string>(nullable: true),
                    LongUrl = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShortUrlMaps", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShortUrlMaps_ShortId",
                table: "ShortUrlMaps",
                column: "ShortId",
                unique: true,
                filter: "[ShortId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShortUrlMaps");
        }
    }
}
