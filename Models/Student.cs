using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolWebApplication.Models;
using System.ComponentModel.DataAnnotations;

namespace SchoolWebApplication.Models
{
    public class Student
    {
        public int Id { get;set; }
        [Required(ErrorMessage = "Поле не повинно бути попрожнім")]
        [Display(Name = "ПІБ")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути попрожнім")]
        [Display(Name = "Рік народження")]
        public int Year { get; set; }
        public int GradeId { get; set; }
        public virtual Grade Grade { get; set; }
    }
}
