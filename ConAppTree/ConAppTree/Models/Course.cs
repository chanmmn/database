using System;
using System.Collections.Generic;

namespace ConAppTree.Models
{
    public partial class Course
    {
        public Course()
        {
            Students = new HashSet<Student>();
        }

        public int CourseId { get; set; }
        public string? CourseName { get; set; }
        public int? TeacherId { get; set; }
        public string? Created { get; set; }

        public virtual Teacher? Teacher { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
