using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolWebApplication.Models;
using System.ComponentModel.DataAnnotations;

namespace SchoolWebApplication.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public int NumbersHoursDayId { get; set; }
        public int GradeId { get; set; }
        public int SubjectsTeacherId { get; set; }
        public int ClassroomId { get; set; }
        public virtual Grade Grade { get; set; }
        public virtual SubjectsTeacher SubjectsTeacher { get; set; }
        public virtual NumbersHoursDay NumbersHoursDay { get; set; }
        public virtual Classroom Classroom { get; set; }
    }
}
