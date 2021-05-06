using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolWebApplication.Models;
using System.ComponentModel.DataAnnotations;

namespace SchoolWebApplication.Models
{
    public class Teacher
    {
        public Teacher()
        {
            SubjectsTeachers = new List<SubjectsTeacher>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути попрожнім")]
        [Display(Name = "ПІБ")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути попрожнім")]
        [Display(Name = "Стаж")]
        public string TeachingExperience { get; set; }
        public virtual ICollection<SubjectsTeacher> SubjectsTeachers { get; set; }
    }
}
