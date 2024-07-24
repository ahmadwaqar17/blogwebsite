using Bloggie.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Bloggie.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed initial data
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "AI" },
                new Category { Id = 2, Name = "Ecommerce" },
                new Category { Id = 3, Name = "Blockchain" },
                new Category { Id = 4, Name = "Web Development" }
            );

            modelBuilder.Entity<BlogPost>().HasData(
                new BlogPost
                {
                    Id = 1,
                    Title = "Artificial Intelligence in Today's World",
                    Content = "Artificial Intelligence (AI) has rapidly transformed various industries, revolutionizing how businesses operate and how individuals interact with technology. From voice assistants like Siri and Alexa to advanced predictive algorithms in healthcare and finance, AI is reshaping our world...",
                    CategoryId = 1,
                    ImagePath = "Downloads/pexels-pixabay-38519.jpg",
                    CreatedAt = DateTime.UtcNow
                },
                new BlogPost
                {
                    Id = 2,
                    Title = "The Role of AI in Healthcare",
                    Content = "Artificial Intelligence (AI) is revolutionizing healthcare by enabling predictive analytics, personalized treatment plans, and improving diagnostic accuracy. From disease detection to patient monitoring, AI is enhancing medical practices...",
                    CategoryId = 1,
                    ImagePath = "Downloads/pexels-pixabay-38519.jpg",
                    CreatedAt = DateTime.UtcNow
                },
                new BlogPost
                {
                    Id = 3,
                    Title = "The Future of Online Shopping",
                    Content = "E-commerce has revolutionized the retail landscape, offering unparalleled convenience and global reach to businesses and consumers alike. With platforms like Amazon and Shopify, shopping has become more accessible, personalized, and efficient than ever before...",
                    CategoryId = 2,
                    ImagePath = "Downloads/pexels-pixabay-38519.jpg",
                    CreatedAt = DateTime.UtcNow
                },
                new BlogPost
                {
                    Id = 4,
                    Title = "Navigating E-commerce Challenges",
                    Content = "Running a successful e-commerce business involves overcoming various challenges, including competition, customer acquisition costs, and logistics. Strategies like personalized marketing and efficient supply chain management are key to thriving in the e-commerce landscape...",
                    CategoryId = 2,
                    ImagePath = "Downloads/pexels-pixabay-38519.jpg",
                    CreatedAt = DateTime.UtcNow
                },
                new BlogPost
                {
                    Id = 5,
                    Title = "Revolutionizing Digital Transactions",
                    Content = "Blockchain technology, initially developed as the underlying technology for Bitcoin, has emerged as a revolutionary force with applications beyond cryptocurrency. Its decentralized and immutable ledger system ensures transparent and secure transactions...",
                    CategoryId = 3,
                    ImagePath = "Downloads/pexels-pixabay-38519.jpg",
                    CreatedAt = DateTime.UtcNow
                },
                new BlogPost
                {
                    Id = 6,
                    Title = "Blockchain: Transforming Supply Chains",
                    Content = "Blockchain technology is revolutionizing supply chain management by enhancing transparency, traceability, and security. From product provenance to logistics optimization, blockchain ensures efficient and trustworthy supply chain operations...",
                    CategoryId = 3,
                    ImagePath = "Downloads/pexels-pixabay-38519.jpg",
                    CreatedAt = DateTime.UtcNow
                },
                new BlogPost
                {
                    Id = 7,
                    Title = "Trends and Innovations in Web Development 2024",
                    Content = "Web development is constantly evolving, driven by advancements in technology and changing user expectations. As we look ahead to 2024, several trends and innovations are shaping the future of web development...",
                    CategoryId = 4,
                    ImagePath = "Downloads/pexels-pixabay-38519.jpg",
                    CreatedAt = DateTime.UtcNow
                },
                new BlogPost
                {
                    Id = 8,
                    Title = "Frontend Frameworks for Web Development",
                    Content = "In 2024, frontend web development is dominated by frameworks like React, Angular, and Vue.js, each offering unique features and capabilities. Choosing the right framework depends on project requirements, scalability needs, and developer expertise...",
                    CategoryId = 4,
                    ImagePath = "Downloads/pexels-pixabay-38519.jpg",
                    CreatedAt = DateTime.UtcNow
                }
            );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "admin", Password = "password" }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
