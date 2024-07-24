using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bloggie.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlogPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogPosts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "AI" },
                    { 2, "Ecommerce" },
                    { 3, "Blockchain" },
                    { 4, "Web Development" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "Username" },
                values: new object[] { 1, "password", "admin" });

            migrationBuilder.InsertData(
                table: "BlogPosts",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedAt", "ImagePath", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Artificial Intelligence (AI) has rapidly transformed various industries, revolutionizing how businesses operate and how individuals interact with technology. From voice assistants like Siri and Alexa to advanced predictive algorithms in healthcare and finance, AI is reshaping our world...", new DateTime(2024, 7, 23, 10, 58, 13, 379, DateTimeKind.Utc).AddTicks(777), "Downloads/pexels-pixabay-38519.jpg", "Artificial Intelligence in Today's World" },
                    { 2, 1, "Artificial Intelligence (AI) is revolutionizing healthcare by enabling predictive analytics, personalized treatment plans, and improving diagnostic accuracy. From disease detection to patient monitoring, AI is enhancing medical practices...", new DateTime(2024, 7, 23, 10, 58, 13, 379, DateTimeKind.Utc).AddTicks(779), "Downloads/pexels-pixabay-38519.jpg", "The Role of AI in Healthcare" },
                    { 3, 2, "E-commerce has revolutionized the retail landscape, offering unparalleled convenience and global reach to businesses and consumers alike. With platforms like Amazon and Shopify, shopping has become more accessible, personalized, and efficient than ever before...", new DateTime(2024, 7, 23, 10, 58, 13, 379, DateTimeKind.Utc).AddTicks(781), "Downloads/pexels-pixabay-38519.jpg", "The Future of Online Shopping" },
                    { 4, 2, "Running a successful e-commerce business involves overcoming various challenges, including competition, customer acquisition costs, and logistics. Strategies like personalized marketing and efficient supply chain management are key to thriving in the e-commerce landscape...", new DateTime(2024, 7, 23, 10, 58, 13, 379, DateTimeKind.Utc).AddTicks(782), "Downloads/pexels-pixabay-38519.jpg", "Navigating E-commerce Challenges" },
                    { 5, 3, "Blockchain technology, initially developed as the underlying technology for Bitcoin, has emerged as a revolutionary force with applications beyond cryptocurrency. Its decentralized and immutable ledger system ensures transparent and secure transactions...", new DateTime(2024, 7, 23, 10, 58, 13, 379, DateTimeKind.Utc).AddTicks(784), "Downloads/pexels-pixabay-38519.jpg", "Revolutionizing Digital Transactions" },
                    { 6, 3, "Blockchain technology is revolutionizing supply chain management by enhancing transparency, traceability, and security. From product provenance to logistics optimization, blockchain ensures efficient and trustworthy supply chain operations...", new DateTime(2024, 7, 23, 10, 58, 13, 379, DateTimeKind.Utc).AddTicks(785), "Downloads/pexels-pixabay-38519.jpg", "Blockchain: Transforming Supply Chains" },
                    { 7, 4, "Web development is constantly evolving, driven by advancements in technology and changing user expectations. As we look ahead to 2024, several trends and innovations are shaping the future of web development...", new DateTime(2024, 7, 23, 10, 58, 13, 379, DateTimeKind.Utc).AddTicks(787), "Downloads/pexels-pixabay-38519.jpg", "Trends and Innovations in Web Development 2024" },
                    { 8, 4, "In 2024, frontend web development is dominated by frameworks like React, Angular, and Vue.js, each offering unique features and capabilities. Choosing the right framework depends on project requirements, scalability needs, and developer expertise...", new DateTime(2024, 7, 23, 10, 58, 13, 379, DateTimeKind.Utc).AddTicks(788), "Downloads/pexels-pixabay-38519.jpg", "Frontend Frameworks for Web Development" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_CategoryId",
                table: "BlogPosts",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogPosts");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
