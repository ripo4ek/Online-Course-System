﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineCourseSystem.DAL.Context;

namespace OnlineCourseSystem.DAL.Migrations
{
    [DbContext(typeof(OnlineCourseSystemContext))]
    [Migration("20190504153302_fixCourses")]
    partial class fixCourses
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int>("Order");

                    b.Property<string>("PhotoUrl");

                    b.Property<string>("Position");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AuthorId");

                    b.Property<string>("CurriculumDesctiption");

                    b.Property<string>("Description");

                    b.Property<int?>("DirectionId");

                    b.Property<DateTime>("Duration");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("Name");

                    b.Property<int>("Order");

                    b.Property<string>("Target");

                    b.Property<int?>("UniversityId");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("DirectionId");

                    b.HasIndex("UniversityId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.CoursesToCategories", b =>
                {
                    b.Property<int>("CategoryId");

                    b.Property<int>("CourseId");

                    b.HasKey("CategoryId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("CoursesToCategories");
                });

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.CoursesToUsers", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<int>("CourseId");

                    b.HasKey("UserId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("CoursesToUsers");
                });

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.Direction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int>("Order");

                    b.HasKey("Id");

                    b.ToTable("Directions");
                });

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.Requierment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CourseId");

                    b.Property<string>("Name");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Requierments");
                });

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.Tasks.QuestionTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CorrectAnswer");

                    b.Property<int?>("CourseId");

                    b.Property<string>("Name");

                    b.Property<int>("Order");

                    b.Property<string>("Question");

                    b.Property<int>("TopicId");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("QuestionTasks");
                });

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.Tasks.QuizTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CourseId");

                    b.Property<string>("Name");

                    b.Property<int>("Order");

                    b.Property<string>("Question");

                    b.Property<int>("TopicId");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("QuizTasks");
                });

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.Tasks.TextTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CourseId");

                    b.Property<string>("Data");

                    b.Property<string>("Name");

                    b.Property<int>("Order");

                    b.Property<int>("TopicId");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("TextTasks");
                });

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.Tasks.VideoTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CourseId");

                    b.Property<string>("Name");

                    b.Property<int>("Order");

                    b.Property<int>("TopicId");

                    b.Property<string>("VideoUrl");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("VideoTasks");
                });

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.Theme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CourseId");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int>("SectionId");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Topics");
                });

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.University", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int>("Order");

                    b.HasKey("Id");

                    b.ToTable("Universities");
                });

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("OnlineCourseSystem.Domain.Model.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("OnlineCourseSystem.Domain.Model.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OnlineCourseSystem.Domain.Model.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("OnlineCourseSystem.Domain.Model.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.Course", b =>
                {
                    b.HasOne("OnlineCourseSystem.Domain.Model.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId");

                    b.HasOne("OnlineCourseSystem.Domain.Model.Direction", "Direction")
                        .WithMany()
                        .HasForeignKey("DirectionId");

                    b.HasOne("OnlineCourseSystem.Domain.Model.University", "University")
                        .WithMany()
                        .HasForeignKey("UniversityId");
                });

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.CoursesToCategories", b =>
                {
                    b.HasOne("OnlineCourseSystem.Domain.Model.Category", "Category")
                        .WithMany("Courses")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OnlineCourseSystem.Domain.Model.Course", "Course")
                        .WithMany("Categories")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.CoursesToUsers", b =>
                {
                    b.HasOne("OnlineCourseSystem.Domain.Model.Course", "Course")
                        .WithMany("Users")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OnlineCourseSystem.Domain.Model.User", "User")
                        .WithMany("Courses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.Requierment", b =>
                {
                    b.HasOne("OnlineCourseSystem.Domain.Model.Course")
                        .WithMany("Requirements")
                        .HasForeignKey("CourseId");
                });

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.Section", b =>
                {
                    b.HasOne("OnlineCourseSystem.Domain.Model.Course")
                        .WithMany("Sections")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.Tasks.QuestionTask", b =>
                {
                    b.HasOne("OnlineCourseSystem.Domain.Model.Course")
                        .WithMany("QuestionTasks")
                        .HasForeignKey("CourseId");
                });

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.Tasks.QuizTask", b =>
                {
                    b.HasOne("OnlineCourseSystem.Domain.Model.Course")
                        .WithMany("QuizTasks")
                        .HasForeignKey("CourseId");
                });

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.Tasks.TextTask", b =>
                {
                    b.HasOne("OnlineCourseSystem.Domain.Model.Course")
                        .WithMany("TextTasks")
                        .HasForeignKey("CourseId");
                });

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.Tasks.VideoTask", b =>
                {
                    b.HasOne("OnlineCourseSystem.Domain.Model.Course")
                        .WithMany("VideoTasks")
                        .HasForeignKey("CourseId");
                });

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.Theme", b =>
                {
                    b.HasOne("OnlineCourseSystem.Domain.Model.Course")
                        .WithMany("Topics")
                        .HasForeignKey("CourseId");
                });
#pragma warning restore 612, 618
        }
    }
}