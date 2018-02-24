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
            //String year,month,day;
            //Console.Write("Enter year: ");
            //year = Console.ReadLine();
            //Console.Write("Enter month: ");
            //month = Console.ReadLine();
            //Console.Write("Enter day: ");
            //day = Console.ReadLine();

            //DateTime dt =  new DateTime(Convert.ToInt32(year),
            //                             Convert.ToInt32(month),
            //                             Convert.ToInt32(day));
            //Console.WriteLine("\n\n" + dt.ToString());
            //Console.ReadLine();



            User us = new User();
            Console.WriteLine("Enter username: ");
            us.Username = Console.ReadLine();
            Console.WriteLine("Enter password: ");
            us.Password = Console.ReadLine();

            LoginValidation logVal = new LoginValidation(us.Username, us.Password, printError);


            User us1 = null;
            if (logVal.ValudateUserInput(out us1))
            //if (logVal.ValudateUserInput(ref us1))
            {
                //Console.WriteLine("Username :" + us1.Username + "\nPassword :" + us1.Password;
                Console.WriteLine("\n\nUsername :" + us1.Username + "\nPassword :" + us1.Password
                    + "\nFakNum :" + us1.FakNum + "\nRole :" + us1.Role);

                //това приложение на switch statement за мен е излишно, 
                // защо трябва да го пишем така ? 
                Console.Write("\n\nCurrent user role from \"_currentUserRole\" is ");
                switch ((Int32)LoginValidation._currentUserRole)
                {
                    case (2):
                        Console.WriteLine("ADMIN");
                        callAdminMenu();
                        break;
                    case (3):
                        Console.WriteLine("INSPECTOR");
                        break;
                    case (4):
                        Console.WriteLine("PROFESSOR");
                        break;
                    case (5):
                        Console.WriteLine("STUDENT");
                        break;
                    default:
                        Console.WriteLine("Something went wrong");
                        break;
                }
                Console.ReadLine();
            }
            else
            {
                Console.Write("\n\nCurrent user role from \"_currentUserRole\" is " + LoginValidation._currentUserRole);
                Console.ReadLine();
            }

             Console.ReadLine(); 
        }
        public static void printError(String errorMessage)
        {
            //DateTime dt = new DateTime(2017, 9, 15, 10, 30, 0);
            //Console.WriteLine("!!!" + dt.Hour + "!!!");
            //Console.WriteLine("!!!" + DateTime.Now + "!!!");
            //Console.WriteLine("!!!" + DateTime.Today + "!!!");

            //DateTime dt1 = DateTime.Today;
            //DayOfWeek dw = dt1.DayOfWeek;
            //Console.WriteLine(dw);
            //int h = dt1.Hour;
            //Console.WriteLine(h);

            //DateTime dt2 = DateTime.Now;
            //DateTime dt3 = dt2.AddHours(12);
            //Console.WriteLine(dt3.Date.ToString());
            Console.WriteLine("!!!" + errorMessage + "!!!");
        }

        public static void callAdminMenu()
        {
            Console.WriteLine("0: Изход");
            Console.WriteLine("1: Промяна на роля на потребител");
            Console.WriteLine("2: Промяна на активност на потребител");

            String Username;

            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 0:
                    break;
                case 1:
                    Console.Write("Enter Username of the user which role you want to change: ");
                    Username = Console.ReadLine();
                    User userToChangeRole;
                    userToChangeRole = UserData.FindUserByUserName(Username);

                    Console.Write("Enter new role for the specified user: ");
                    String newRole = Console.ReadLine().Trim().ToUpper();

                    UserRoles convertedRoleToEnum = (UserRoles)Enum.Parse(typeof(UserRoles), newRole);
                    foreach (UserRoles userRole in Enum.GetValues(typeof(UserRoles)))
                    {
                        if (userRole == convertedRoleToEnum)
                        {
                            userToChangeRole.Role = Convert.ToInt32(convertedRoleToEnum);
                        }
                    }

                    break;
                case 2:
                    Console.Write("Enter Username of the user which activity period you want to change: ");
                    Username = Console.ReadLine();
                    Console.WriteLine("Enter the end of the active period for the specified user : ");
                    String year, month, day;
                    Console.Write("Enter year: ");
                    year = Console.ReadLine();
                    Console.Write("Enter month: ");
                    month = Console.ReadLine();
                    Console.Write("Enter day: ");
                    day = Console.ReadLine();

                    DateTime dt = new DateTime(Convert.ToInt32(year),
                                                 Convert.ToInt32(month),
                                                 Convert.ToInt32(day));

                    Username = Console.ReadLine();
                    UserData.SetUserActiveTo(Username, dt);


                    break;
                default:
                    Console.WriteLine("No such option!");
                    break;

            }
        }
    }
}
