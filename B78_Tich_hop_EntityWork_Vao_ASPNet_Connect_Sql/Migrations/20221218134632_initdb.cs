using System;
using Bogus;
using Microsoft.EntityFrameworkCore.Migrations;
using razorweb.modles;

#nullable disable

namespace TichhopEntityWorkVaoASPNetConnectSql.Migrations
{
    /// <inheritdoc />
    public partial class initdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "articles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Content = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articles", x => x.id);
                });


                // Insert data cách thủ công
                // migrationBuilder.InsertData(
                //     table: "articles",
                //     columns: new []{"Title", "Created", "Content"},
                //     values: new object [] {
                //         "Bai viet 1", new DateTime(2022, 8, 20), "Noi dung 1"
                //     }
                // );


                // InsertData cách tự động Fake Data: sử dụng Nuget Bogus, sau đó chọn Project website để coppy code trên Gitthub về

                Randomizer.Seed = new Random(8675309);
                // Sau đó ta tạo một đối tượng Fake và thiết lập các quy luật để nó tạo ra dữ liệu
                var fakeArticle = new Faker<Article>();
                fakeArticle.RuleFor(a => a.Title, f => f.Lorem.Sentence(5, 5)); // Thiết lập câu văn từ 5 đến 10 ký tự
                fakeArticle.RuleFor(a => a.Created, f => f.Date.Between(new DateTime(2022, 1, 1), new DateTime(2022, 7, 30)));
                fakeArticle.RuleFor(a => a.Content, f => f.Lorem.Paragraphs(1, 4));     // Phát sinh đoạn văn


                for(int i=0; i< 50; i++)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "articles");
        }
    }
}
