using System;
using Bogus;
using Microsoft.EntityFrameworkCore.Migrations;
using razprweb.models;

#nullable disable

namespace IdentityRazorWeb.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articles", x => x.Id);
                });

            Randomizer.Seed = new Random(8675309);

            var fakeArticle = new Faker<Article>();
            fakeArticle.RuleFor(article => article.Title, fakeArticle => fakeArticle.Lorem.Sentence(5, 5));
            fakeArticle.RuleFor(article => article.Created, fakeArticle => fakeArticle.Date.Between(new DateTime(2022, 1, 1), new DateTime(2022, 7, 30)));
            fakeArticle.RuleFor(article => article.Content, fakeArticle => fakeArticle.Lorem.Paragraphs(4, 7));

            for(int i=0; i< 150; i++)
            {
                Article article = fakeArticle.Generate();
                migrationBuilder.InsertData(
                    table: "articles",
                    columns: new [] {"Title", "Created", "Content"},
                    values: new object [] {
                        article.Title, article.Created, article.Content
                    }
                );
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "articles");
        }
    }
}
