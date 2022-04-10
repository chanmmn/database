using System;
using System.Collections.Generic;

namespace ConAppTree.Models
{
    public partial class Student
    {
        public Student()
        {
            Courses = new HashSet<Course>();
        }

        public int StudentId { get; set; }
        public string? StudentName { get; set; }
        public int? StandardId { get; set; }
        public byte[] RowVersion { get; set; } = null!;

        public virtual Standard? Standard { get; set; }
        public virtual StudentAddress StudentAddress { get; set; } = null!;

        public virtual ICollection<Course> Courses { get; set; }
    }
}
