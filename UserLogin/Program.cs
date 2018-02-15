using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    class Program
    {
        static void Main(string[] args)
        {
            /* User us = new User();
             us.Username = "AdminName";
             us.Password = "PassAdmin";
             us.FakNum = "323232";
             us.Role = 1; */

            User us = new User();
            Console.WriteLine("Enter username: ");
            us.Username = Console.ReadLine();
            Console.WriteLine("Enter password: ");
            us.Password = Console.ReadLine();

            LoginValidation logVal = new LoginValidation(us.Username, us.Password);

            User us1 = null;
            if (logVal.ValudateUserInput(out us1))
            {
                Console.WriteLine("Username :" + us1.Username + "\nPassword :" + us1.Password
                    + "\nFakNum :" + us1.FakNum + "\nRole :" + us1.Role);
                Console.ReadLine();
            }
            else
            {
                Console.ReadLine();
            }

            /* User us = new User();
             Console.WriteLine("Enter username: ");
             us.Username = Console.ReadLine();
             Console.WriteLine("Enter password: ");
             us.Password = Console.ReadLine();
             Console.WriteLine("Enter FakNum: ");
             us.FakNum = Console.ReadLine();
             Console.WriteLine("Enter Role: ");
             us.Role = Convert.ToInt32(Console.ReadLine());

             Console.WriteLine("Username :" + us.Username + "\n Password :" + us.Username + "\n FakNum :" + us.Username + "\n Role :" + us.Role);

             Console.ReadLine(); */
        }
    }
}
