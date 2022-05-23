using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Travel_Agency.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PacchettoViaggio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Immagine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destinazione = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TipoPensione = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    StelleHotel = table.Column<int>(type: "int", nullable: false),
                    NumerOspiti = table.Column<int>(type: "int", nullable: false),
                    Prezzo = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacchettoViaggio", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PacchettoViaggio_Id",
                table: "PacchettoViaggio",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PacchettoViaggio");
        }
    }
}
