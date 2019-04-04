using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCourseSystem.Domain.Model.Base
{
    interface IOrderedEntity
    {
        /// <summary>
        /// Порядок
        /// </summary>
        int Order { get; set; }
    }
}
