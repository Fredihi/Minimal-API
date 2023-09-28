using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Minimal_API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReleaseYear = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "ID", "Author", "Description", "Genre", "Name", "ReleaseYear" },
                values: new object[,]
                {
                    { 1, "Robert McLeod", "Dive into the heroic stories of Scottish warriors throughout the history, chronicling their bravery and sacrifices on the battlefield.", "Scottish Military History", "Braveheart and Battles", new DateTime(2022, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Fiona Campbell", "Explore the intricate web of clan conflicts that shaped Scotland's history, from ancient feuds to power struggles.", "Scottish Clan Warfare", "Clan Conflicts", new DateTime(2019, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Angus MacGregor", "Examine the events leading up to the Battle of Culloden  in 1746, the tragic culmination of the Jacobite uprising, and it's impact on Scotland", "Jacobite Uprising", "Culloden: Last Stand of the Highlanders", new DateTime(2020, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Isobel Fraser", "Trace the battle that defined medieval Scotland, including the iconinc Battle of Bannockburn and the devastating Battle of Flodden.", "Medieval Scottish Warfare", "From Bannockburn to Flodden", new DateTime(2017, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Malcolm Sinclair", "Shed light on the lesser-known stories of Scottish soldiers and their contributions during World War I, highlighting their sacrifices on the global stage.", "Scottish Involvement in WWI", "Forgotten Frontlines: World War I", new DateTime(2023, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
