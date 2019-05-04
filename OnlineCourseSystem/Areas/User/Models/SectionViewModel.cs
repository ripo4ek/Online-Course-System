using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineCourseSystem.Domain.Model.Base;

namespace OnlineCourseSystem.Areas.User.Models
{
    public class SectionViewModel : INamedEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public SectionViewModel()
        {
            ChildSections = new List<SectionViewModel>();
        }

        /// <summary> 
        /// Дочерние	 секции	 
        /// </summary> 
        public List<SectionViewModel> ChildSections { get; set; }

        /// <summary> 
        /// Родительская	 секция	 
        /// </summary> 
        public SectionViewModel ParentSection { get; set; }


    }
}
