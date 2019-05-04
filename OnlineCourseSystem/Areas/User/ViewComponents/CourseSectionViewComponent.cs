using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineCourseSystem.Areas.User.Infrastucture.Interfaces;
using OnlineCourseSystem.Areas.User.Models;

namespace OnlineCourseSystem.Areas.User.ViewComponents
{
    public class SectionsViewComponent : ViewComponent
    {
        private readonly ICourseData _courseData;

        public SectionsViewComponent(ICourseData courseData)
        {
            _courseData = courseData;
        }
        public async Task<IViewComponentResult> InvokeAsync(int idOfCourse)
        {
            var sections = GetSections(idOfCourse);
            return View(sections);
        }

        private List<SectionViewModel> GetSections(int idOfCourse)
        {
            var sections = _courseData.GetSections().Where(c => c.CourseId == idOfCourse);
            var themes = _courseData.GetThemes().Where(t => t.Id == idOfCourse);
            var viewSections = new List<SectionViewModel>();

            foreach (var section in sections)
            {
                viewSections.Add(new SectionViewModel()
                {
                    Id = section.Id,
                    Name = section.Name,
                    ParentSection = null,
                });
            }

            foreach (var section in viewSections)
            {
                var themesForSection = themes.Where(t => t.SectionId == section.Id);
                foreach (var theme in themesForSection)
                {
                    section.ChildSections.Add(new SectionViewModel()
                    {
                        Id = theme.Id,
                        Name = theme.Name
                    });
                }
            }

            return viewSections;
        }
    }
}
