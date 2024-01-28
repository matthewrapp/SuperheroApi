using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperheroApi.Migrations
{
   /// <inheritdoc />
   public partial class AddSuperHerosTable : Migration
   {
      /// <inheritdoc />
      protected override void Up(MigrationBuilder migrationBuilder)
      {
         migrationBuilder.CreateTable(
             name: "SuperHeroes",
             columns: table => new
             {
                Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Superpowers = table.Column<string>(type: "nvarchar(max)", nullable: true)
             },
             constraints: table =>
             {
                table.PrimaryKey("PK_SuperHeroes", x => x.Id);
             });
      }

      /// <inheritdoc />
      protected override void Down(MigrationBuilder migrationBuilder)
      {
         migrationBuilder.DropTable(
             name: "SuperHeroes");
      }
   }
}
