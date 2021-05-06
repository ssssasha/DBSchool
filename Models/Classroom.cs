using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolWebApplication.Models;
using System.ComponentModel.DataAnnotations;

namespace SchoolWebApplication.Models
{
    public class Classroom
    {
        public Classroom()
        {
            Schedules = new List<Schedule>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage="Поле не повинно бути попрожнім")]
        [Display(Name ="Номер кабінету")]
        public int Number { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути попрожнім")]
        [Display(Name = "Номер поверху")]
        public int Floor { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
