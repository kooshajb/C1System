using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C1System.DataLayar.Migrations
{
    public partial class Category : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    SubTitle = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IconImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IntroDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IntroImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BannerTitle = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    BannerDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BannerImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IconMenuImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VideoIntro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubCategory = table.Column<int>(type: "int", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_SubCategory",
                        column: x => x.SubCategory,
                        principalTable: "Categories",
                        principalColumn: "CategoryId");
                });

            migrationBuilder.CreateTable(
                name: "CategoryPackageItems",
                columns: table => new
                {
                    CategoryPackageItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    TitleInfo = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryPackageItems", x => x.CategoryPackageItemId);
                });

            migrationBuilder.CreateTable(
                name: "CategoryPackages",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    SubTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryPackages", x => x.CategoryId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_SubCategory",
                table: "Categories",
                column: "SubCategory");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "CategoryPackageItems");

            migrationBuilder.DropTable(
                name: "CategoryPackages");
        }
    }
}
