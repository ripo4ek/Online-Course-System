﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using OnlineCourseSystem.DAL.Context;
using System;

namespace OnlineCourseSystem.DAL.Migrations
{
    [DbContext(typeof(OnlineCourseSystemContext))]
    [Migration("20190430132906_fixedManyToMany")]
    partial class fixedManyToMany
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

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
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

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

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.Direction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("Order");

                    b.HasKey("Id");

                    b.ToTable("Directions");
                });

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.Requierment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

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
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CourseId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.Tasks.QuestionTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CourseId");

                    b.Property<string>("Name");

                    b.Property<int>("TopicId");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("QuestionTasks");
                });

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.Tasks.QuizTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CourseId");

                    b.Property<string>("Name");

                    b.Property<string>("Question");

                    b.Property<int>("TopicId");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("QuizTasks");
                });

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.Tasks.TextTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CourseId");

                    b.Property<string>("Name");

                    b.Property<int>("TopicId");

                    b.Property<string>("VideoUrl");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("TextTask");
                });

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.Tasks.VideoTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CourseId");

                    b.Property<string>("Name");

                    b.Property<int>("TopicId");

                    b.Property<string>("VideoUrl");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("VideoTasks");
                });

            modelBuilder.Entity("OnlineCourseSystem.Domain.Model.Theme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

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
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("Order");

                    b.HasKey("Id");

                    b.ToTable("Universities");
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
