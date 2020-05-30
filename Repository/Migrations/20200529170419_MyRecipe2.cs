using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class MyRecipe2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeEntity");

            migrationBuilder.CreateTable(
                name: "Recipe",
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
                    table.PrimaryKey("PK_Recipe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Step",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: false),
                    Rank = table.Column<int>(nullable: false),
                    RecipeId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Step", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Step_Recipe_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Step_RecipeId",
                table: "Step",
                column: "RecipeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Step");

            migrationBuilder.DropTable(
                name: "Recipe");

            migrationBuilder.CreateTable(
                name: "RecipeEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CookingDuration = table.Column<int>(type: "int", nullable: false),
                    CoolingDuration = table.Column<int>(type: "int", nullable: false),
                    DifficultyLevel = table.Column<int>(type: "int", nullable: false),
                    PersCount = table.Column<int>(type: "int", nullable: false),
                    PrepDuration = table.Column<int>(type: "int", nullable: false),
                    RecommendedAssociation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WaitingDuration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeEntity", x => x.Id);
                });
        }
    }
}
