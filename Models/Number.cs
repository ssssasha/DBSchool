using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolWebApplication.Models;
using System.ComponentModel.DataAnnotations;

namespace SchoolWebApplication.Models
{
    public class Number
    {
        public Number()
        {
            NumbersHoursDays = new List<NumbersHoursDay>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути попрожнім")]
        [Display(Name = "Порядковий номер")]
        public int NumberName { get; set; }
        public virtual ICollection<NumbersHoursDay> NumbersHoursDays { get; set; }
    }
}
