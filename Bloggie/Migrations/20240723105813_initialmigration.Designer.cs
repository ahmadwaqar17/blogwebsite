﻿// <auto-generated />
using System;
using Bloggie.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bloggie.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240723105813_initialmigration")]
    partial class initialmigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Bloggie.Models.BlogPost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("BlogPosts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Content = "Artificial Intelligence (AI) has rapidly transformed various industries, revolutionizing how businesses operate and how individuals interact with technology. From voice assistants like Siri and Alexa to advanced predictive algorithms in healthcare and finance, AI is reshaping our world...",
                            CreatedAt = new DateTime(2024, 7, 23, 10, 58, 13, 379, DateTimeKind.Utc).AddTicks(777),
                            ImagePath = "Downloads/pexels-pixabay-38519.jpg",
                            Title = "Artificial Intelligence in Today's World"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Content = "Artificial Intelligence (AI) is revolutionizing healthcare by enabling predictive analytics, personalized treatment plans, and improving diagnostic accuracy. From disease detection to patient monitoring, AI is enhancing medical practices...",
                            CreatedAt = new DateTime(2024, 7, 23, 10, 58, 13, 379, DateTimeKind.Utc).AddTicks(779),
                            ImagePath = "Downloads/pexels-pixabay-38519.jpg",
                            Title = "The Role of AI in Healthcare"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            Content = "E-commerce has revolutionized the retail landscape, offering unparalleled convenience and global reach to businesses and consumers alike. With platforms like Amazon and Shopify, shopping has become more accessible, personalized, and efficient than ever before...",
                            CreatedAt = new DateTime(2024, 7, 23, 10, 58, 13, 379, DateTimeKind.Utc).AddTicks(781),
                            ImagePath = "Downloads/pexels-pixabay-38519.jpg",
                            Title = "The Future of Online Shopping"
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            Content = "Running a successful e-commerce business involves overcoming various challenges, including competition, customer acquisition costs, and logistics. Strategies like personalized marketing and efficient supply chain management are key to thriving in the e-commerce landscape...",
                            CreatedAt = new DateTime(2024, 7, 23, 10, 58, 13, 379, DateTimeKind.Utc).AddTicks(782),
                            ImagePath = "Downloads/pexels-pixabay-38519.jpg",
                            Title = "Navigating E-commerce Challenges"
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 3,
                            Content = "Blockchain technology, initially developed as the underlying technology for Bitcoin, has emerged as a revolutionary force with applications beyond cryptocurrency. Its decentralized and immutable ledger system ensures transparent and secure transactions...",
                            CreatedAt = new DateTime(2024, 7, 23, 10, 58, 13, 379, DateTimeKind.Utc).AddTicks(784),
                            ImagePath = "Downloads/pexels-pixabay-38519.jpg",
                            Title = "Revolutionizing Digital Transactions"
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 3,
                            Content = "Blockchain technology is revolutionizing supply chain management by enhancing transparency, traceability, and security. From product provenance to logistics optimization, blockchain ensures efficient and trustworthy supply chain operations...",
                            CreatedAt = new DateTime(2024, 7, 23, 10, 58, 13, 379, DateTimeKind.Utc).AddTicks(785),
                            ImagePath = "Downloads/pexels-pixabay-38519.jpg",
                            Title = "Blockchain: Transforming Supply Chains"
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 4,
                            Content = "Web development is constantly evolving, driven by advancements in technology and changing user expectations. As we look ahead to 2024, several trends and innovations are shaping the future of web development...",
                            CreatedAt = new DateTime(2024, 7, 23, 10, 58, 13, 379, DateTimeKind.Utc).AddTicks(787),
                            ImagePath = "Downloads/pexels-pixabay-38519.jpg",
                            Title = "Trends and Innovations in Web Development 2024"
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 4,
                            Content = "In 2024, frontend web development is dominated by frameworks like React, Angular, and Vue.js, each offering unique features and capabilities. Choosing the right framework depends on project requirements, scalability needs, and developer expertise...",
                            CreatedAt = new DateTime(2024, 7, 23, 10, 58, 13, 379, DateTimeKind.Utc).AddTicks(788),
                            ImagePath = "Downloads/pexels-pixabay-38519.jpg",
                            Title = "Frontend Frameworks for Web Development"
                        });
                });

            modelBuilder.Entity("Bloggie.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "AI"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Ecommerce"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Blockchain"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Web Development"
                        });
                });

            modelBuilder.Entity("Bloggie.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Password = "password",
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("Bloggie.Models.BlogPost", b =>
                {
                    b.HasOne("Bloggie.Models.Category", "Category")
                        .WithMany("BlogPosts")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Bloggie.Models.Category", b =>
                {
                    b.Navigation("BlogPosts");
                });
#pragma warning restore 612, 618
        }
    }
}
