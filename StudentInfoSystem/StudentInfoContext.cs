using StudentRepository;
using UserLogin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    class StudentInfoContext : DbContext
    {
        //Base constructor
        public StudentInfoContext(): base(Properties.Settings.Default.DbConnect)  { }
        //properties
        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }

        public bool TestStudentsUsersIfEmpty()
        {
            bool emptyUserOrStudentTb = true;

            StudentInfoContext context = new StudentInfoContext();
            IEnumerable<Student> queryStudents = context.Students;
            IEnumerable<User> queryUsers = context.Users;

            int countUsers = queryUsers.Count();
            int countStudents = queryStudents.Count();

            if (countUsers == 0)
            {
                CopyTestUsers();
            }
            else
            {
                emptyUserOrStudentTb = false;
            }

            if (countStudents == 0)
            {
                CopyTestStudents();
            }
            else
            {
                emptyUserOrStudentTb = false;
            }
            return emptyUserOrStudentTb;
        }
       
        void CopyTestStudents()
        {
            StudentInfoContext context = new StudentInfoContext();
            foreach (Student st in StudentData.TestStudents)
            {
                context.Students.Add(st);
            }
            context.SaveChanges();
        }

        void CopyTestUsers()
        {
            StudentInfoContext context = new StudentInfoContext();
            foreach (User u in UserData.TestUsers)
            {
                context.Users.Add(u);
            }
            context.SaveChanges();
        }
    }
}
