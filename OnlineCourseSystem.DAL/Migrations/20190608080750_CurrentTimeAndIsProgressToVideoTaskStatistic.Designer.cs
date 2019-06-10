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
    [Migration("20190608080750_CurrentTimeAndIsProgressToVideoTaskStatistic")]
    partial class CurrentTimeAndIsProgressToVideoTaskStatistic
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Description");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Name");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("PhotoUrl");

                    b.Property<string>("SecurityStamp");

                    b.Property<string>("Status");

                    b.Property<string>("Surname");

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

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.ApplicationUserRole", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
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

                    b.Property<string>("AuthorId");

                    b.Property<string>("CurriculumDescription");

                    b.Property<string>("Description");

                    b.Property<string>("DurationInHours");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("LocalImageUrl");

                    b.Property<string>("Name");

                    b.Property<string>("RequirementKnowledge");

                    b.Property<string>("TargetAuditory");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

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

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("ImageLocalUrl");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("Name");

                    b.Property<string>("OrganizerId");

                    b.Property<string>("Text");

                    b.Property<DateTime>("Time");

                    b.HasKey("Id");

                    b.HasIndex("OrganizerId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AuthorId");

                    b.Property<string>("ImageLocalUrl");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("Name");

                    b.Property<DateTime>("ReleaseTime");

                    b.Property<string>("Text");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.QuestionTaskStatistic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CourseStatisticId");

                    b.Property<bool>("IsComplete");

                    b.Property<bool>("IsCorrect");

                    b.Property<string>("Name");

                    b.Property<int>("TaskId");

                    b.Property<string>("UserAnswer");

                    b.HasKey("Id");

                    b.HasIndex("CourseStatisticId");

                    b.ToTable("QuestionTaskStatistics");
                });

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.QuizTaskStatistic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CourseStatisticId");

                    b.Property<bool>("IsComplete");

                    b.Property<bool>("IsCorrect");

                    b.Property<string>("Name");

                    b.Property<int>("TaskId");

                    b.Property<string>("UserVariant");

                    b.HasKey("Id");

                    b.HasIndex("CourseStatisticId");

                    b.ToTable("QuizTaskStatistics");
                });

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.QuizVariant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("QuizTaskId");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("QuizTaskId");

                    b.ToTable("QuizVariants");
                });

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.Requierment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.ToTable("Requierments");
                });

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.Role", b =>
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

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseId");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.Tasks.CourseStatistic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApplicationUserId");

                    b.Property<int>("CourseId");

                    b.Property<bool>("IsCompleted");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("CourseStatistics");
                });

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.Tasks.QuestionTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CorrectAnswer");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int>("Order");

                    b.Property<string>("Question");

                    b.Property<int>("TopicId");

                    b.HasKey("Id");

                    b.HasIndex("TopicId");

                    b.ToTable("QuestionTasks");
                });

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.Tasks.QuizTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CorrectAnswerId");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int>("Order");

                    b.Property<string>("Question");

                    b.Property<int>("TopicId");

                    b.HasKey("Id");

                    b.HasIndex("CorrectAnswerId");

                    b.HasIndex("TopicId");

                    b.ToTable("QuizTasks");
                });

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.Tasks.TextTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Data");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int>("Order");

                    b.Property<int>("TopicId");

                    b.HasKey("Id");

                    b.HasIndex("TopicId");

                    b.ToTable("TextTasks");
                });

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.Tasks.VideoTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("LocalVideoUrl");

                    b.Property<string>("Name");

                    b.Property<int>("Order");

                    b.Property<int>("TopicId");

                    b.Property<string>("VideoUrl");

                    b.HasKey("Id");

                    b.HasIndex("TopicId");

                    b.ToTable("VideoTasks");
                });

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.TextTaskStatistics", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CourseStatisticId");

                    b.Property<bool>("IsComplete");

                    b.Property<bool>("IsCorrect");

                    b.Property<string>("Name");

                    b.Property<int>("TaskId");

                    b.HasKey("Id");

                    b.HasIndex("CourseStatisticId");

                    b.ToTable("TextTaskStatistics");
                });

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.Topic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int>("SectionId");

                    b.HasKey("Id");

                    b.HasIndex("SectionId");

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

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.VideoTaskStatistic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CourseStatisticId");

                    b.Property<double>("CurrentTime");

                    b.Property<bool>("InProgress");

                    b.Property<bool>("IsComplete");

                    b.Property<bool>("IsCorrect");

                    b.Property<string>("Name");

                    b.Property<int>("TaskId");

                    b.HasKey("Id");

                    b.HasIndex("CourseStatisticId");

                    b.ToTable("VideoTaskStatistic");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("OnlineCourseSystem.Domain.Model.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("OnlineCourseSystem.Domain.Model.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("OnlineCourseSystem.Domain.Model.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("OnlineCourseSystem.Domain.Model.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.ApplicationUserRole", b =>
                {
                    b.HasOne("OnlineCourseSystem.Domain.Model.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OnlineCourseSystem.Domain.Model.ApplicationUser", "ApplicationUser")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.Course", b =>
                {
                    b.HasOne("OnlineCourseSystem.Domain.Model.ApplicationUser", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId");
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

                    b.HasOne("OnlineCourseSystem.Domain.Model.ApplicationUser", "ApplicationUser")
                        .WithMany("Courses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.Event", b =>
                {
                    b.HasOne("OnlineCourseSystem.Domain.Model.ApplicationUser", "Organizer")
                        .WithMany()
                        .HasForeignKey("OrganizerId");
                });

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.Post", b =>
                {
                    b.HasOne("OnlineCourseSystem.Domain.Model.ApplicationUser", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId");
                });

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.QuestionTaskStatistic", b =>
                {
                    b.HasOne("OnlineCourseSystem.Domain.Model.Tasks.CourseStatistic")
                        .WithMany("QuestionTaskStatistics")
                        .HasForeignKey("CourseStatisticId");
                });

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.QuizTaskStatistic", b =>
                {
                    b.HasOne("OnlineCourseSystem.Domain.Model.Tasks.CourseStatistic")
                        .WithMany("QuizTaskStatistics")
                        .HasForeignKey("CourseStatisticId");
                });

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.QuizVariant", b =>
                {
                    b.HasOne("OnlineCourseSystem.Domain.Model.Tasks.QuizTask")
                        .WithMany("VariantOfAnswers")
                        .HasForeignKey("QuizTaskId");
                });

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.Section", b =>
                {
                    b.HasOne("OnlineCourseSystem.Domain.Model.Course")
                        .WithMany("Sections")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.Tasks.CourseStatistic", b =>
                {
                    b.HasOne("OnlineCourseSystem.Domain.Model.ApplicationUser")
                        .WithMany("CourseStatistics")
                        .HasForeignKey("ApplicationUserId");
                });

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.Tasks.QuestionTask", b =>
                {
                    b.HasOne("OnlineCourseSystem.Domain.Model.Topic")
                        .WithMany("QuestionTasks")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.Tasks.QuizTask", b =>
                {
                    b.HasOne("OnlineCourseSystem.Domain.Model.QuizVariant", "CorrectAnswer")
                        .WithMany()
                        .HasForeignKey("CorrectAnswerId");

                    b.HasOne("OnlineCourseSystem.Domain.Model.Topic")
                        .WithMany("QuizTasks")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.Tasks.TextTask", b =>
                {
                    b.HasOne("OnlineCourseSystem.Domain.Model.Topic")
                        .WithMany("TextTasks")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.Tasks.VideoTask", b =>
                {
                    b.HasOne("OnlineCourseSystem.Domain.Model.Topic")
                        .WithMany("VideoTasks")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.TextTaskStatistics", b =>
                {
                    b.HasOne("OnlineCourseSystem.Domain.Model.Tasks.CourseStatistic")
                        .WithMany("TextTaskStatistics")
                        .HasForeignKey("CourseStatisticId");
                });

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.Topic", b =>
                {
                    b.HasOne("OnlineCourseSystem.Domain.Model.Section")
                        .WithMany("Topics")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.VideoTaskStatistic", b =>
                {
                    b.HasOne("OnlineCourseSystem.Domain.Model.Tasks.CourseStatistic")
                        .WithMany("VideoTaskStatistics")
                        .HasForeignKey("CourseStatisticId");
                });
#pragma warning restore 612, 618
        }
    }
}
