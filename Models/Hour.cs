using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolWebApplication.Models;
using System.ComponentModel.DataAnnotations;

namespace SchoolWebApplication.Models
{
    public class Hour
    {
        public Hour()
        {
            NumbersHoursDays = new List<NumbersHoursDay>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути попрожнім")]
        [Display(Name = "Час")]
        public string Time { get; set; }
        public virtual ICollection<NumbersHoursDay> NumbersHoursDays { get; set; }
    }
}
