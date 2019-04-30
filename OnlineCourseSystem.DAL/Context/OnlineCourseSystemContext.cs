﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineCourseSystem.Domain.Model;
using OnlineCourseSystem.Domain.Model.Base;
using OnlineCourseSystem.Domain.Model.Tasks;
using OnlineCourseSystem.Domain.Model.Users;


namespace OnlineCourseSystem.DAL.Context
{
    public class OnlineCourseSystemContext: IdentityDbContext<User>
    {
        public OnlineCourseSystemContext(DbContextOptions options) : 
            base(options)
        {
             
        }
            public DbSet<Course> Courses { get; set; }
            public DbSet<Author> Authors { get; set; }
            public DbSet<Direction> Directions { get; set; }
            public DbSet<Section> Sections { get; set; }
            public DbSet<Theme> Topics { get; set; }
            public DbSet<University> Universities { get; set; }
            public DbSet<VideoTask> VideoTasks { get; set; }
            public DbSet<QuizTask> QuizTasks { get; set; }
            public DbSet<QuestionTask> QuestionTasks { get; set; }
            public DbSet<Category> Categories{ get; set; }

            public DbSet<Requierment> Requierments { get; set; }

        public DbSet<CoursesToCategories> CoursesToCategories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
            modelBuilder.Entity<CoursesToCategories>()
                .HasKey(t => new { t.CategoryId, t.CourseId });

            modelBuilder.Entity<CoursesToCategories>()
                .HasOne(sc => sc.Course)
                .WithMany(s => s.Categories)
                .HasForeignKey(sc => sc.CourseId);

            modelBuilder.Entity<CoursesToCategories>()
                .HasOne(sc => sc.Category)
                .WithMany(c => c.Courses)
                .HasForeignKey(sc => sc.CategoryId);
        }

    }
}
