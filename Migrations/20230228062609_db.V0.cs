using Bogus;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;
using RazorPage.Models;

#nullable disable

namespace RazorPage.Migrations
{
    /// <inheritdoc />
    public partial class dbV0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articles", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");



            // Insert data inital
            // by Bogus
            Randomizer.Seed = new Random(8675309);
            var fakerArticle = new Faker<Article>();
            fakerArticle.RuleFor(ar => ar.Title, faker => faker.Lorem.Sentence(5, 10));
            fakerArticle.RuleFor(ar => ar.Created, faker =>
                faker.Date.Between(new DateTime(2015, 9, 15), new DateTime(2023, 2, 28)));

            fakerArticle.RuleFor(ar => ar.Content, faker => faker.Lorem.Paragraphs(1, 3));


            for (int i = 0; i < 100; i++)
            {
                var article = fakerArticle.Generate();
                migrationBuilder.InsertData(
                    table: "articles",
                    columns: new[] { "Title", "Created", "Content" },
                    values: new object[] {
                        article.Title,
                        article.Created,
                        article.Content
                    }
                );
            }


            // by hand

            //migrationBuilder.InsertData(
            // "articles",
            // new[] { "Title", "Created", "Content" },
            //new object[] { "bai viet 2", new DateTime(2023, 2, 27), "noi dung 2" }
            //);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "articles");
        }
    }
}
