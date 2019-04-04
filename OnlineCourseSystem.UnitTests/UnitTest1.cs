using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using OnlineCourseSystem;
using OnlineCourseSystem.DAL.Context;
using OnlineCourseSystem.Domain.Model;

namespace Tests
{
    public class SqlCourseDataTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetCourse_()
        {
            var moq = new Mock<OnlineCourseSystemContext>();
            
        }
    }
}