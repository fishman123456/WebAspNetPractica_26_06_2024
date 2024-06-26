using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAspNetPractica_26_06_2024.DB
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mountainPeaks",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mountainSystem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mountainName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mountainHeight = table.Column<int>(type: "int", nullable: false),
                    countryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mountainPeaks", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mountainPeaks");
        }
    }
}
