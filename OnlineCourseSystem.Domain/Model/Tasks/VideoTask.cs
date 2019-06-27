using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using OnlineCourseSystem.Domain.Model.Base;

namespace OnlineCourseSystem.Domain.Model.Tasks
{
    [Table("VideoTasks")]
    public class VideoTask : Task
    {
        /// <summary>
        /// Ссылка на видео
        /// </summary>
        ///
        public string VideoUrl { get; set; }
        public string LocalVideoUrl { get; set; }

    }
}
