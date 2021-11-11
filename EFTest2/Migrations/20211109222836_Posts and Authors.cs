using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFTest2.Migrations
{
    public partial class PostsandAuthors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PrimaryEmail",
                table: "Blogs",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsPublished = table.Column<bool>(type: "bit", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlogId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Posts_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "BlogId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AuthorPost",
                columns: table => new
                {
                    AuthorsEmail = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PostsPostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorPost", x => new { x.AuthorsEmail, x.PostsPostId });
                    table.ForeignKey(
                        name: "FK_AuthorPost_Authors_AuthorsEmail",
                        column: x => x.AuthorsEmail,
                        principalTable: "Authors",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorPost_Posts_PostsPostId",
                        column: x => x.PostsPostId,
                        principalTable: "Posts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_PrimaryEmail",
                table: "Blogs",
                column: "PrimaryEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorPost_PostsPostId",
                table: "AuthorPost",
                column: "PostsPostId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_BlogId",
                table: "Posts",
                column: "BlogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Authors_PrimaryEmail",
                table: "Blogs",
                column: "PrimaryEmail",
                principalTable: "Authors",
                principalColumn: "Email",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Authors_PrimaryEmail",
                table: "Blogs");

            migrationBuilder.DropTable(
                name: "AuthorPost");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_PrimaryEmail",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "PrimaryEmail",
                table: "Blogs");
        }
    }
}
