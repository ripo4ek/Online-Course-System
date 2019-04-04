using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCourseSystem.Domain.Model.Base
{
    public interface INamedEntity : IBaseEntity
    {
        /// <summary>
        /// Наименование
        /// </summary>
        string Name { get; set; }
    }
}
