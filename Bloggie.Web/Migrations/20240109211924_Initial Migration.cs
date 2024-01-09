using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bloggie.Web.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlogPosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Heading = table.Column<string>(type: "varchar(200)", nullable: false),
                    PageTitle = table.Column<string>(type: "varchar(200)", nullable: false),
                    Content = table.Column<string>(type: "varchar(200)", nullable: false),
                    ShortDescription = table.Column<string>(type: "varchar(200)", nullable: false),
                    FeaturedImageUrl = table.Column<string>(type: "varchar(200)", nullable: false),
                    UrlHandle = table.Column<string>(type: "varchar(200)", nullable: false),
                    PublishedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Author = table.Column<string>(type: "varchar(200)", nullable: false),
                    Visible = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPosts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false),
                    BlogPostId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogPosts");

            migrationBuilder.DropTable(
                name: "Tags");
        }
    }
}
