using System;
using System.IO;
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
            if (logVal.ValudateUserInput(ref us1))
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

                callAdminMenu();
                Console.ReadLine();
            }
            else
            {
                printError("\n\nCurrent user role from \"_currentUserRole\" is " + LoginValidation._currentUserRole);
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
            Console.WriteLine("\n\n0: Изход");
            Console.WriteLine("1: Промяна на роля на потребител");
            Console.WriteLine("2: Промяна на активност на потребител");
            Console.WriteLine("3: Списък на потребителите");
            Console.WriteLine("4: Преглед на лог на активност");
            Console.WriteLine("5: Преглед на текуща активност");


            String Username;
            Dictionary<string, Int32> allusers = UserData.AllUsersUsernames();


            Console.Write("\n\nMake your choice: ");
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 0:
                    Environment.Exit(0);
                    break;
                case 1:
                    Console.Write("\nEnter Username of the user which role you want to change: ");
                    Username = Console.ReadLine();

                    
                    Console.WriteLine("\nEnter the new role for the specified using one of the following words : ");
                    Console.WriteLine("ANONYMOS, ADMIN, INSPECTOR, PROFESSOR, STUDENT ");
                    Console.Write("Make your choice: ");
                   
                    String newRole = Console.ReadLine().Trim().ToUpper();

                    UserRoles convertedRoleToEnum = (UserRoles)Enum.Parse(typeof(UserRoles), newRole);
                    bool wasTheRoleChanged = false;
                    foreach (UserRoles userRole in Enum.GetValues(typeof(UserRoles)))
                    {
                        if (userRole == convertedRoleToEnum)
                        {
                            wasTheRoleChanged = true;
                            UserData.AssignUserRole(allusers[Username], convertedRoleToEnum);
                        }
                    }
                    if (wasTheRoleChanged != true)
                    {
                        Console.WriteLine("The role you have chosen was not found in the list of roles !\n\n");
                        callAdminMenu();
                    }

                    break;
                case 2:
                    Console.Write("\nEnter Username of the user which activity period you want to change: ");
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

                    UserData.SetUserActiveTo(allusers[Username], dt);
                    String result = "Периодът на активност на " + Username +" беше променен до " + dt.ToString();
                    Logger.logActivity(result);
                    Console.WriteLine(result);

                    callAdminMenu();
                    break;

                case 3:
                    //Dictionary<string, int> allUsers = UserData.AllUsersUsernames();
                    foreach (KeyValuePair<string, int> item in allusers)
                    {
                        Console.WriteLine(item.Key);
                    }
                    callAdminMenu();
                    break;
                case 4:
                    if (File.Exists("test.txt"))
                    {
                        Console.WriteLine(File.ReadAllText("test.txt"));
                        Console.ReadLine();
                    }
                    callAdminMenu();
                    break;
                case 5:
                    Console.Write("\nPlease enter your searching filter: ");
                    Logger.GetCurrentSessionActivities(Console.ReadLine());
                    break;
                default:
                    printError("No such option!");
                    Console.ReadLine();
                    break;

            }
        }
    }
}
