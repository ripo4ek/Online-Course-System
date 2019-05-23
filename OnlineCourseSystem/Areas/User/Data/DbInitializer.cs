using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineCourseSystem.DAL.Context;
using  OnlineCourseSystem.Domain.Model;
using OnlineCourseSystem.Domain.Model.Base;
using OnlineCourseSystem.Domain.Model.Tasks;

namespace OnlineCourseSystem.Areas.User.Data
{
    public static class DbInitializer
    {
        public static void Initialize(OnlineCourseSystemContext context)
        {
            context.Database.EnsureCreated();
            if (context.Courses.Any())
            {
                return;
            }

            var universities = new List<University>()
            {
                new University()
                {
                    Id = 1,
                    Name = "ITMO",
                    Order = 0

                },
                new University()
                {
                    Id = 2,
                    Name = "Pomoika",
                    Order = 1

                },

            };
            using (var trans = context.Database.BeginTransaction())
            {
                foreach (var university in universities)
                {
                    context.Universities.Add(university);
                }
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Universities] ON");
                context.SaveChanges();
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Universities] OFF");
                trans.Commit();
            }
            var authors = new List<Author>()
            {
                new Author()
                {
                    Id = 1,
                    Name = "Admin",
                    Order = 0

                },
                new Author()
                {
                    Id = 2,
                    Name = "RandomGuy",
                    Order = 1

                },

            };

            var directions = new List<Direction>()
            {
                new Direction()
                {
                    Id = 1,
                    Name = "Informatics and Math",
                    Order = 0
                },

            };
            using (var trans = context.Database.BeginTransaction())
            {
                foreach (var direction in directions)
                {
                    context.Directions.Add(direction);
                }
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Directions] ON");
                context.SaveChanges();
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Directions] OFF");
                trans.Commit();
            }


            var courses = new List<Course>()
            {
                new Course()
                {
                    Id = 1,
                    Name = "C# Start",
                    Order = 0,
                    Description = "C# For Newbee",
                    DirectionId = 1,
                    ImageUrl = "Course1.png",
                    
                    UniversityId = 1,
                    
                    
                },
                new Course()
                {
                    Id = 2,
                    Name = "C# Essential",
                    Order = 1,
                    Description = "C# for pepole who's know something",
                    DirectionId = 1,
                    ImageUrl = "Course2.png",
                    
                    UniversityId = 1,
                    
                },
                new Course()
                {
                    Id = 3,
                    Name = "Java Starter",
                    Order = 2,
                    Description = "For Gays",
                    DirectionId = 1,
                    ImageUrl = "Course3.png",
                    
                    UniversityId = 2,
                    
                },
                
            };
            using (var trans = context.Database.BeginTransaction())
            {
                foreach (var course in courses)
                {
                    context.Courses.Add(course);
                }

                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Courses] ON");
                context.SaveChanges();
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Courses] OFF");
                trans.Commit();
            }


            var sections = new List<Section>()
            {
                new Section()
                {
                    Id = 1,
                    Name = "Introducing C#",
                    
                    CourseId = 1
                },
                new Section()
                {
                    Id = 2,
                    Name = "In the middle of C#",
                    
                    CourseId = 1
                },
                new Section()
                {
                    Id = 3,
                    Name = "In the end of C#",
                    
                    CourseId = 1
                },
                new Section()
                {
                    Id = 4,
                    Name = "Java Gay's Starter",
                   
                    CourseId = 3
                },
                new Section()
                {
                    Id = 5,
                    Name = " C# Essential Start",
                   
                    CourseId = 2
                },
            };
            using (var trans = context.Database.BeginTransaction())
            {
                foreach (var section in sections)
                {
                    context.Sections.Add(section);
                }

                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Sections] ON");
                context.SaveChanges();
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Sections] OFF");
                trans.Commit();
            }

            var topics = new List<Topic>()
            {
                new Topic()
                {
                    Id = 1,
                    Name = "Hello, World",
                    SectionId = 1,
                   
                },
                new Topic()
                {
                    Id = 2,
                    Name = "Types of Data C#",
                    SectionId = 1,
                    
                },
                new Topic()
                {
                    Id = 3,
                    Name = "Cycles and logic",
                    SectionId = 1,
                   
                },
                new Topic()
                {
                    Id = 4,
                    Name = "Methods",
                    SectionId = 2,
                    
                },
                new Topic()
                {
                    Id = 5,
                    Name = "OOP",
                    SectionId = 3,
                   
                },
                new Topic()
                {
                    Id = 6,
                    Name = "How to put your dick into the man ass",
                    SectionId = 4,
                    
                },
            };
            using (var trans = context.Database.BeginTransaction())
            {
                foreach (var topic in topics)
                {
                    context.Topics.Add(topic);
                }
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Topics] ON");
                context.SaveChanges();
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Topics] OFF");
                trans.Commit();
            }





            var videoTasks = new List<VideoTask>()
            {
                new VideoTask()
                {
                    Id = 1,
                    Name = "Hello World Video",
                    TopicId = 1,
                    VideoUrl = "video1"
                },
            };
            using (var trans = context.Database.BeginTransaction())
            {
                foreach (var video in videoTasks)
                {
                    context.VideoTasks.Add(video);
                }
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[VideoTasks] ON");
                context.SaveChanges();
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[VideoTasks] OFF");
                trans.Commit();
            }
            var QuizTasks = new List<QuizTask>()
            {

                new QuizTask()
                {
                    Id = 2,
                    Name = "Hello World Test",
                    TopicId = 1,
                    CorrectAnswer = new QuizVariant()
                    {
                        Id = 1,
                        Text = "Hello World"
                    },
                    Question = "Как правильно?",
                    VariantOfAnswers = new List<QuizVariant>()
                    {
                        new QuizVariant(){Text = "Hi world"},
                        new QuizVariant(){Text = "Хай кста"},
                        new QuizVariant(){Text ="HW"}
                    }
                },
                new QuizTask()
                {
                    Id = 3,
                    Name = "Types of Var Test",
                    TopicId = 2,
                    CorrectAnswer = new QuizVariant()
                    {
                        Id = 1,
                        Text = "Hello World"
                    },
                    Question = "Как правильно?",
                    VariantOfAnswers = new List<QuizVariant>()
                    {
                        new QuizVariant(){Text = "Hi world"},
                        new QuizVariant(){Text = "Хай кста"},
                        new QuizVariant(){Text ="HW"}
                    }
                },
            };
            using (var trans = context.Database.BeginTransaction())
            {
                foreach (var quizTasks in QuizTasks)
                {
                    context.QuizTasks.Add(quizTasks);
                }
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[QuizTasks] ON");
                context.SaveChanges();
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[QuizTasks] OFF");
                trans.Commit();
            }
            


        }
    }
}
