using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolWebApplication.Models;
using System.ComponentModel.DataAnnotations;

namespace SchoolWebApplication.Models
{
    public class NumbersHoursDay
    {
        public NumbersHoursDay()
        {
            Schedules = new List<Schedule>();
        }
        public int Id { get; set; }
        public int DayId { get; set; }
        public int NumberId { get; set; }
        public int HourId { get; set; }
        public virtual Number Number { get; set; }
        public virtual Hour Hour { get; set; }
        public virtual Day Day { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
