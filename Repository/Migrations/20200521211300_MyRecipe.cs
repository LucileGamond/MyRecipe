using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class MyRecipe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RecipeEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PersCount = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    PrepDuration = table.Column<int>(nullable: false),
                    CookingDuration = table.Column<int>(nullable: false),
                    CoolingDuration = table.Column<int>(nullable: false),
                    WaitingDuration = table.Column<int>(nullable: false),
                    RecommendedAssociation = table.Column<string>(nullable: true),
                    DifficultyLevel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeEntity", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeEntity");
        }
    }
}
