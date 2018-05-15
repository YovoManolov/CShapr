using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRepository
{
    class StudentContext : DbContext
    {
        public StudentContext() : base(Properties.Settings.Default.DbConnect) { }
        public DbSet<Student> Students { get; set; }

        private static List<Student> getStudents()
        {
            StudentContext context = new StudentContext();
            List<Student> students = context.Students.ToList();
            return students;
        }

    }
}
