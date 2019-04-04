using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCourseSystem.Domain.Model.Base
{
    public interface IBaseEntity
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        int Id { get; set; }
    }
}
