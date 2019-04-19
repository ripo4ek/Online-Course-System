using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using Microsoft.EntityFrameworkCore;
using OnlineCourseSystem.Domain.Model;
using OnlineCourseSystem.Domain.Model.Base;
using OnlineCourseSystem.Domain.Model.Tasks;


namespace OnlineCourseSystem.DAL.Context
{
    public class OnlineCourseSystemContext: DbContext
    {
        public OnlineCourseSystemContext(DbContextOptions options) : 
            base(options)
        {
             
        }
            public DbSet<Course> Courses { get; set; }
            public DbSet<Author> Authors { get; set; }
            public DbSet<Direction> Directions { get; set; }
            public DbSet<Section> Sections { get; set; }
            public DbSet<Topic> Topics { get; set; }
            public DbSet<University> Universities { get; set; }
            public DbSet<VideoTask> VideoTasks { get; set; }
            public DbSet<QuizTask> QuizTasks { get; set; }
            public DbSet<QuestionTask> QuestionTasks { get; set; }
            public DbSet<Category> Categories{ get; set; }

            public DbSet<CoursesToCategories> CoursesToCategories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Course>()
                    .HasKey(x => x.Id);

                modelBuilder.Entity<Category>()
                    .HasKey(x => x.Id);

                modelBuilder.Entity< CoursesToCategories>()
                    .HasKey(x => new { x.CourseId, x.CategoryId });
                modelBuilder.Entity<CoursesToCategories>()
                    .HasOne(x => x.Course)
                    .WithMany(m => m.Categories)
                    .HasForeignKey(x => x.CourseId);
                modelBuilder.Entity<CoursesToCategories>()
                    .HasOne(x => x.Category)
                    .WithMany(e => e.Courses)
                    .HasForeignKey(x => x.CategoryId);
            }

    }
}
