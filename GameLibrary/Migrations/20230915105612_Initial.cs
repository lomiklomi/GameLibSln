using GameLibrary.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameLibrary.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    GameId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
					GenreId = table.Column<string>(type: "int", nullable: false),
					DeveloperId = table.Column<string>(type: "int", nullable: false)
				},
                constraints: table =>
                {
					table.PrimaryKey("PK_Game_GameId", x => x.GameId);
					table.ForeignKey(
						name: "FK_Game_Genre_GenreId",
						column: x => x.GenreId,
						principalTable: "Genre",
						principalColumn: "GenreId",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_Game_Developer_DeveloperId",
						column: x => x.DeveloperId,
						principalTable: "Developer",
						principalColumn: "DeveloperId",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "Genre",
				columns: table => new
				{
					GenreId = table.Column<long>(type: "bigint", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Genre_GenreId", x => x.GenreId);
					table.UniqueConstraint("AK_Genre_Name", x => x.Name);
				});

			migrationBuilder.CreateTable(
				name: "Developer",
				columns: table => new
				{
					DeveloperId = table.Column<long>(type: "bigint", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Developer_GenreId", x => x.DeveloperId);
					table.UniqueConstraint("AK_Developer_Name", x => x.Name);
				});
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Game");

			migrationBuilder.DropTable(
				name: "Genre");

			migrationBuilder.DropTable(
				name: "Developer");
		}
    }
}
