using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineCourseSystem.Domain.Model;
using OnlineCourseSystem.Domain.Model.Base;
using OnlineCourseSystem.Domain.Model.Tasks;


namespace OnlineCourseSystem.DAL.Context
{
    public class OnlineCourseSystemContext: IdentityDbContext<ApplicationUser, Role, string, IdentityUserClaim<string>,
        ApplicationUserRole, IdentityUserLogin<string>,
        IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public OnlineCourseSystemContext(DbContextOptions options) : 
            base(options)
        {
             
        }
            public DbSet<News> News { get; set; }
            public DbSet<Blog> Blogs { get; set; }
            public DbSet<QuestionTaskStatistic> QuestionTaskStatistics { get; set; }
            public DbSet<VideoTaskStatistic> VideoTaskStatistic { get; set; }
            public DbSet<Event> Events { get; set; }
            public DbSet<TextTaskStatistics> TextTaskStatistics { get; set; }
            public DbSet<QuizTaskStatistic> QuizTaskStatistics { get; set; }
            public DbSet<CourseStatistic> CourseStatistics { get; set; }
            public DbSet<Course> Courses { get; set; }
            public DbSet<Direction> Directions { get; set; }
            public DbSet<Section> Sections { get; set; }
            public DbSet<Topic> Topics { get; set; }
            public DbSet<University> Universities { get; set; }
            public DbSet<VideoTask> VideoTasks { get; set; }
            public DbSet<QuizTask> QuizTasks { get; set; }
            public DbSet<QuestionTask> QuestionTasks { get; set; }
            public DbSet<Category> Categories{ get; set; }
            public DbSet<TextTask> TextTasks { get; set; }
            public DbSet<Requierment> Requierments { get; set; }
            public DbSet<CoursesToUsers> CoursesToUsers { get; set; }
            public DbSet<CoursesToCategories> CoursesToCategories { get; set; }
            public DbSet<QuizVariant> QuizVariants { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);


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

            modelBuilder.Entity<CoursesToUsers>()
                .HasKey(t => new { t.UserId, t.CourseId });

            modelBuilder.Entity<CoursesToUsers>()
                .HasOne(sc => sc.Course)
                .WithMany(s => s.Users)
                .HasForeignKey(sc => sc.CourseId);

            modelBuilder.Entity<CoursesToUsers>()
                .HasOne(sc => sc.ApplicationUser)
                .WithMany(c => c.Courses)
                .HasForeignKey(sc => sc.UserId);

            modelBuilder.Entity<ApplicationUserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.ApplicationUser)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });
        }

    }
}
