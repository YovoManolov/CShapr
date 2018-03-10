using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLogin;

namespace StudentRepository
{
    class StudentValidation
    {
        public Student GetStudentDataByUser(User u)
        {
            Student st = null;
            
            if (u.FakNum != null)
            {
                long fakNum = long.Parse(u.FakNum);
                st = StudentData.isThereSudent(fakNum);
                if (st == null)
                {
                    Console.WriteLine("Студент с такъв факултетен номер не беше намерен!");
                }
            }
            else
            {
                Console.WriteLine("В подадения от Вас потребител не присъстваше факултетен номер, чрез който да намерите студент!");
            }

            return st;
        }
    }
}
