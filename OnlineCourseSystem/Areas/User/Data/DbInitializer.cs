using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OnlineCourseSystem.Areas.User.Models;
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


            var categories = new List<Category>()
            {
                new Category()
                {
                    Id = 1,
                    Name = "Programming"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Art"
                }
            };
            using (var trans = context.Database.BeginTransaction())
            {
                foreach (var category in categories)
                {
                    context.Categories.Add(category);
                }

                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Categories] ON");
                context.SaveChanges();
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Categories] OFF");
                trans.Commit();
            }

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore, new OptionsManager<IdentityOptions>(new OptionsFactory<IdentityOptions>(new IConfigureOptions<IdentityOptions>[] { },
                    new IPostConfigureOptions<IdentityOptions>[] { })),
                new PasswordHasher<ApplicationUser>(), new IUserValidator<ApplicationUser>[] { }, new IPasswordValidator<ApplicationUser>[] { },
                new UpperInvariantLookupNormalizer(), new IdentityErrorDescriber(), null, null);
            var firstAuthor = new ApplicationUser() { UserName = "FirstAuthor", Email = "FirstAuthor@mail.com" };
            var result = userManager.CreateAsync(firstAuthor, "firstAuthor").Result;
            if (result == IdentityResult.Success)
            {
                var roleResult = userManager.AddToRoleAsync(firstAuthor, Roles.CourseCreator).Result;
            }
            var secondAuthor = new ApplicationUser() { UserName = "SecondAuthor", Email = "SecondAuthor@mail.com" };
            var resultTwo = userManager.CreateAsync(secondAuthor, "secondAuthor").Result;
            if (resultTwo == IdentityResult.Success)
            {
                var roleResult = userManager.AddToRoleAsync(secondAuthor, Roles.CourseCreator).Result;
            }
            var thirdAuthor = new ApplicationUser() { UserName = "ThirdAuthor", Email = "ThirdAuthor@mail.com" };
            var resultThree = userManager.CreateAsync(thirdAuthor, "thirdAuthor").Result;
            if (resultThree == IdentityResult.Success)
            {
                var roleResult = userManager.AddToRoleAsync(thirdAuthor, Roles.CourseCreator).Result;
            }

            var courses = new List<Course>()
            {
                new Course()
                {
                    Id = 1,
                    Author = firstAuthor,
                    Name = "C# Start",
                    Description = "C# For Newbee",
                    CurriculumDescription = "We will learn some basic things. Cycles, Arrays, Objects, OOP etc.",
                    DurationInHours = "12",
                    RequirementKnowledge = "None",
                    TargetAuditory = "Anyone",
                    Sections = new List<Section>()
                    {
                        new Section()
                        {
                            Name = "Beginning",
                            Description = "Let's get acquainted",
                            Topics = new List<Topic>()
                            {
                                new Topic()
                                {
                                    VideoTasks= new List<VideoTask>()
                                    {
                                        new VideoTask()
                                        {
                                            Name = "Variables",
                                            Description = "About Variables",
                                            Order = 0,                                           
                                        }
                                    },
                                    Name = "Variables",
                                    Description= "The root of Knowlage",
                                    QuestionTasks = new List<QuestionTask>()
                                    {
                                        new QuestionTask()
                                        {
                                            Name = "First Question",
                                            Description = "Let's begin",
                                            Question = "In what style should we call variables?",
                                            CorrectAnswer = "pascalCase",
                                            Order = 1,
                                        },
                                    },
                                    QuizTasks = new List<QuizTask>()
                                    {
                                        new QuizTask()
                                        {
                                            Name = "Keyword",
                                            Description = "Let's test what u learned",
                                            CorrectAnswer = new QuizVariant(){Text = "var"},
                                            Question = "What word is using for encapsulation?",
                                            VariantOfAnswers = new List<QuizVariant>()
                                            {
                                                new QuizVariant(){Text = "dynamic"},
                                                new QuizVariant(){Text = "var"},
                                                new QuizVariant(){Text = "int"}
                                            },
                                            Order = 2,
                                        }
                                    },
                                    
                                },
                                new Topic()
                                {
                                    Name = "Cycles",
                                    Description= "About cycles",
                                    VideoTasks= new List<VideoTask>()
                                    {
                                        new VideoTask()
                                        {
                                            Name = "Cycles Beginning",
                                            Description = "About cycles",
                                            Order = 0,
                                        }
                                    },

                                    QuestionTasks = new List<QuestionTask>()
                                    {
                                        new QuestionTask()
                                        {
                                            Name = "First Question",
                                            Description = "Let's begin",
                                            Question = "How many types of cycles we have in c#?",
                                            CorrectAnswer = "3",
                                            Order = 1,
                                        },
                                    },
                                    QuizTasks = new List<QuizTask>()
                                    {
                                        new QuizTask()
                                        {
                                            Name = "Type of Cycles",
                                            Description = "Let's test what u learned",
                                            CorrectAnswer = new QuizVariant(){Text = "do-while"},
                                            Question = "Cycle with pre-condition?",
                                            VariantOfAnswers = new List<QuizVariant>()
                                            {
                                                new QuizVariant(){Text = "do-while"},
                                                new QuizVariant(){Text = "while-do"},
                                                new QuizVariant(){Text = "for"}
                                            },
                                            Order = 2,
                                        }
                                    },
                                    TextTasks = new List<TextTask>()
                                    {
                                        new TextTask()
                                        {
                                            Name = "Fun facts",
                                            Description = "Some information form meditations",
                                            Order = 3,
                                            Data = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut auctor fermentum mollis. Integer ac neque ut lacus dictum tincidunt quis sit amet dolor. Nullam dictum leo non ornare ullamcorper. Integer varius magna ac hendrerit bibendum. Mauris dictum enim ut sagittis lobortis. Cras ultrices ipsum in odio eleifend mattis. Fusce mattis maximus mi, nec dictum dolor condimentum at. Etiam ornare vestibulum leo a consectetur. Nullam a nunc pharetra, facilisis eros at, faucibus mi. Pellentesque suscipit sem molestie metus molestie, vitae scelerisque lectus cursus. Aliquam lobortis risus at felis mollis, eget cursus dolor rhoncus. Donec ac porta tortor. Curabitur finibus eros ac mauris aliquet ultricies. Quisque vitae laoreet orci. Mauris orci tortor, aliquet at sapien id, dignissim sodales mauris."
                                        }
                                    }

                                }
                            }
                        },
                        new Section()
                        {
                            Name = "Middle",
                            Description = "In the middle of way",
                            Topics = new List<Topic>()
                            {
                                new Topic()
                                {
                                    VideoTasks= new List<VideoTask>()
                                    {
                                        new VideoTask()
                                        {
                                            Name = "Variables",
                                            Description = "About Variables",
                                            Order = 0,
                                        }
                                    },
                                    Name = "Variables",
                                    Description= "The root of Knowlage",
                                    QuestionTasks = new List<QuestionTask>()
                                    {
                                        new QuestionTask()
                                        {
                                            Name = "First Question",
                                            Description = "Let's begin",
                                            Question = "In what style should we call variables?",
                                            CorrectAnswer = "pascalCase",
                                            Order = 1,
                                        },
                                    },
                                    QuizTasks = new List<QuizTask>()
                                    {
                                        new QuizTask()
                                        {
                                            Name = "Keyword",
                                            Description = "Let's test what u learned",
                                            CorrectAnswer = new QuizVariant(){Text = "var"},
                                            Question = "What word is using for encapsulation?",
                                            VariantOfAnswers = new List<QuizVariant>()
                                            {
                                                new QuizVariant(){Text = "dynamic"},
                                                new QuizVariant(){Text = "var"},
                                                new QuizVariant(){Text = "int"}
                                            },
                                            Order = 2,
                                        }
                                    },

                                },
                                new Topic()
                                {
                                    Name = "Cycles",
                                    Description= "About cycles",
                                    VideoTasks= new List<VideoTask>()
                                    {
                                        new VideoTask()
                                        {
                                            Name = "Cycles Beginning",
                                            Description = "About cycles",
                                            Order = 0,
                                        }
                                    },

                                    QuestionTasks = new List<QuestionTask>()
                                    {
                                        new QuestionTask()
                                        {
                                            Name = "First Question",
                                            Description = "Let's begin",
                                            Question = "How many types of cycles we have in c#?",
                                            CorrectAnswer = "3",
                                            Order = 1,
                                        },
                                    },
                                    QuizTasks = new List<QuizTask>()
                                    {
                                        new QuizTask()
                                        {
                                            Name = "Type of Cycles",
                                            Description = "Let's test what u learned",
                                            CorrectAnswer = new QuizVariant(){Text = "do-while"},
                                            Question = "Cycle with pre-condition?",
                                            VariantOfAnswers = new List<QuizVariant>()
                                            {
                                                new QuizVariant(){Text = "do-while"},
                                                new QuizVariant(){Text = "while-do"},
                                                new QuizVariant(){Text = "for"}
                                            },
                                            Order = 2,
                                        }
                                    },
                                    TextTasks = new List<TextTask>()
                                    {
                                        new TextTask()
                                        {
                                            Name = "Fun facts",
                                            Description = "Some information form meditations",
                                            Order = 3,
                                            Data = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut auctor fermentum mollis. Integer ac neque ut lacus dictum tincidunt quis sit amet dolor. Nullam dictum leo non ornare ullamcorper. Integer varius magna ac hendrerit bibendum. Mauris dictum enim ut sagittis lobortis. Cras ultrices ipsum in odio eleifend mattis. Fusce mattis maximus mi, nec dictum dolor condimentum at. Etiam ornare vestibulum leo a consectetur. Nullam a nunc pharetra, facilisis eros at, faucibus mi. Pellentesque suscipit sem molestie metus molestie, vitae scelerisque lectus cursus. Aliquam lobortis risus at felis mollis, eget cursus dolor rhoncus. Donec ac porta tortor. Curabitur finibus eros ac mauris aliquet ultricies. Quisque vitae laoreet orci. Mauris orci tortor, aliquet at sapien id, dignissim sodales mauris."
                                        }
                                    }

                                }
                            }
                        },
                    }

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


            var coursesTocategories = new List<CoursesToCategories>()
            {
                new CoursesToCategories()
                {
                    CategoryId = 1,
                    CourseId = 1,
                },
                new CoursesToCategories()
                {
                    CategoryId = 2,
                    CourseId = 2,
                },
            };
            using (var trans = context.Database.BeginTransaction())
            {
                foreach (var coursesTocategory in coursesTocategories)
                {
                    context.CoursesToCategories.Add(coursesTocategory);
                }

                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[CoursesToCategories] ON");
                context.SaveChanges();
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[CoursesToCategories] OFF");
                trans.Commit();
            }

            var news = new List<News>()
            {
                new News()
                {
                    Author = firstAuthor,
                    Name = "Welcome",
                    ReleaseTime = DateTime.Now,
                    Text = "We glad to introduce out platform. The future is here",
                },
            };
            using (var trans = context.Database.BeginTransaction())
            {
                foreach (var n in news)
                {
                    context.News.Add(n);
                }

                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[News] ON");
                context.SaveChanges();
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[News] OFF");
                trans.Commit();
            }
            var blogs = new List<Blog>()
            {
                new Blog()
                {
                    Author = firstAuthor,
                    Name = "About C# Datetime",
                    ReleaseTime = DateTime.Now,
                    Text = "The DateTime data type is used to work with date and times in C#. The DateTime class in C# provides properties and methods to format dates in different datetime formats. This article explains how to work with date and time format in C#. The following table describes various date time formats and their results. Here we see all the patterns of the DateTime Class.",
                },
            };
            using (var trans = context.Database.BeginTransaction())
            {
                foreach (var blog in blogs)
                {
                    context.Blogs.Add(blog);
                }

                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Blogs] ON");
                context.SaveChanges();
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Blogs] OFF");
                trans.Commit();
            }
            var events = new List<Event>()
            {
                new Event()
                {
                    Organizer = firstAuthor,
                    Name = "Meetup about future of our platform",
                    Address = "Baker St. 12",
                    Time = DateTime.Now,                 
                    Text = "The DateTime data type is used to work with date and times in C#. The DateTime class in C# provides properties and methods to format dates in different datetime formats. This article explains how to work with date and time format in C#. The following table describes various date time formats and their results. Here we see all the patterns of the DateTime Class.",
                },
            };
            using (var trans = context.Database.BeginTransaction())
            {
                foreach (var ev in events)
                {
                    context.Events.Add(ev);
                }

                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Events] ON");
                context.SaveChanges();
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Events] OFF");
                trans.Commit();
            }



        }
    }
}
