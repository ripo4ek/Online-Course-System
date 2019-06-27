using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineCourseSystem.Areas.User.Infrastucture.Interfaces;
using OnlineCourseSystem.Areas.User.Models;

namespace OnlineCourseSystem.Areas.User.ViewComponents
{
    public class CategoriesViewComponent : ViewComponent
    {
        private readonly ICourseData _courseData;

        public CategoriesViewComponent(ICourseData courseData)
        {
            _courseData = courseData;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var categories = _courseData.GetCategories();
          
            var categoriesModel = new List<CategoryViewModel>();

            foreach (var category in categories)
            {
                var countCourses = _courseData.GetCoursesCountOfCategory(category.Id);
                categoriesModel.Add(new CategoryViewModel
                {
                    FullString = $"{category.Name} ({countCourses})",
                    Category = category.Name
                });
            }
            var model = new CategoriesViewModel()
            {
                Categories = categoriesModel
            };

            return View(model);
        }
    }
}
