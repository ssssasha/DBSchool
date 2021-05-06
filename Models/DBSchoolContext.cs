using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SchoolWebApplication.Models
{
    public class DBSchoolContext : DbContext
    {
        public virtual DbSet<Classroom> Classrooms { get; set; }
        public virtual DbSet<Day> Days { get; set; }
        public virtual DbSet<Grade> Grades { get; set; }
        public virtual DbSet<Hour> Hours { get; set; }
        public virtual DbSet<Number> Numbers { get; set; }
        public virtual DbSet<NumbersHoursDay> NumbersHoursDays { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<SubjectsTeacher> SubjectsTeachers { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }

        public DBSchoolContext(DbContextOptions<DBSchoolContext> options)
           : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
