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
           
            User us = new User();
            RightsGranted rg = new RightsGranted();

            Console.WriteLine("Въведете потребителско име : ");
            us.Username = Console.ReadLine();
            Console.WriteLine("Въведете парола : ");
            us.Password = Console.ReadLine();

            LoginValidation logVal = new LoginValidation(us.Username, us.Password, printError);


            User us1 = null;
            if (logVal.ValudateUserInput(ref us1))
            {
               
                Console.WriteLine("\n\nПотеребителско име :" + us1.Username + "\nПарола :" + us1.Password
                    + "\nФакултетен номер :" + us1.FakNum + "\nРоля :" + us1.Role);

                UserData.UserRoleOfCurrUser = us1.Role;

                Console.Write("\n\nРолята на потребителя, който използва приложението е : ");
                switch ((Int32)LoginValidation._currentUserRole)
                {
                    case (2):
                        Console.WriteLine("Администратор");
                        callMenu(us1.Role);
                        break;
                    case (3):
                        Console.WriteLine("Инспектор");
                        callMenu(us1.Role);
                        break;
                    case (4):
                        Console.WriteLine("Професор");
                        callMenu(us1.Role);
                        break;
                    case (5):
                        Console.WriteLine("Студент");
                        callMenu(us1.Role);
                        break;
                    default:
                        Console.WriteLine("Нещо се обърка");
                        break;
                }

                Console.ReadLine();
            }
            else
            {
                printError("\n\nРолята на потребителя, който използва приложението е : " + LoginValidation._currentUserRole);
                Console.ReadLine();
            }
             Console.ReadLine(); 
        }
        public static void printError(String errorMessage)
        {
            Console.WriteLine("!!!" + errorMessage + "!!!");
        }

        public static void callMenu(int uR)
        {
            List<RoleRights> currUsRR =
                            RightsGranted.getRightsByRole((UserRoles) uR-1);
          //CanEditUsers,CanSeeLogs,CanEditStudents
            
            String Username;
            Dictionary<string, Int32> allusers = UserData.AllUsersUsernames();
            int myChoiceOfMenuOption = -1;

            if (currUsRR.Contains(RoleRights.CanEditUsers)&&
                    currUsRR.Contains(RoleRights.CanSeeLogs))
            {
                Console.WriteLine("\n\n0: Изход");
                Console.WriteLine("1: Промяна на роля на потребител");
                Console.WriteLine("2: Промяна на активност на потребител");
                Console.WriteLine("3: Списък на потребителите");
                Console.WriteLine("4: Преглед на лог на активност");
                Console.WriteLine("5: Преглед на текуща активност");
                Console.Write("\n\nНаправете своя избор: ");
                myChoiceOfMenuOption = Convert.ToInt32(Console.ReadLine());
                if (myChoiceOfMenuOption > 5)
                {
                    Console.WriteLine("Невалиденa oпция от предоставеното Ви меню! ");
                    Console.WriteLine("Моля направете отново Вашия избор: ");
                    callMenu(uR);
                }

            }
            else if(currUsRR.Contains(RoleRights.CanEditUsers))
            {
                Console.WriteLine("\n\n0: Изход");
                Console.WriteLine("1: Промяна на роля на потребител");
                Console.WriteLine("2: Промяна на активност на потребител");
                Console.WriteLine("3: Списък на потребителите");
                Console.Write("\n\nНаправете своя избор: ");
                myChoiceOfMenuOption = Convert.ToInt32(Console.ReadLine());
                if (myChoiceOfMenuOption > 3)
                {
                    Console.WriteLine("Невалиденa oпция от предоставеното Ви меню! ");
                    Console.WriteLine("Моля направете отново Вашия избор: ");
                    callMenu(uR);
                }
            }
            else
            {
                Console.WriteLine("Нямате права за опциите налични в текущата система !");
                Console.WriteLine("\n0: Изход");

                myChoiceOfMenuOption = Convert.ToInt32(Console.ReadLine());
                if (myChoiceOfMenuOption != 0)
                {
                    Console.WriteLine("Невалиденa oпция от предоставеното Ви меню! ");
                    Console.WriteLine("Моля направете отново Вашия избор: ");
                    callMenu(uR);
                }
            }

            if(myChoiceOfMenuOption <0)
            {
              Console.WriteLine("Невалиден избор на опция от менюто!");
              Console.WriteLine("Моля опитайте отново!");
              callMenu(uR);
            }
            switch (myChoiceOfMenuOption)
            {
                case 0:
                    Environment.Exit(0);
                    break;
                case 1:
                    Console.Write("\nВъведете потребителското име на потребителя, чиято роля искате да промените: ");
                    Username = Console.ReadLine();
                    UserData.assignRoleByUsername(Username);
                    break;
                case 2:
                    Console.Write("\nEnter Username of the user which activity period you want to change: ");
                    Username = Console.ReadLine();
                    UserData.chngAtivPerByUsername(Username);
                    break;
                case 3:
                    foreach (KeyValuePair<string, int> item in allusers)
                    {
                        Console.WriteLine(item.Key);
                    }
                    callMenu(uR);
                    break;
                case 4:
                    Console.WriteLine("Лог на активност:");
                    if (File.Exists("test.txt"))
                    {
                        Console.WriteLine("\n\n"+File.ReadAllText("test.txt"));
                        Console.ReadLine();
                    }
                    callMenu(uR);
                    break;
                case 5:
                    Console.Write("\nМоля въведете дума по която да направите Вашето търсене: ");
                    Logger.GetCurrentSessionActivities(Console.ReadLine());
                    break;
                default:
                    printError("Невалидна опция !");
                    Console.ReadLine();
                    break;
            }
        }
    }
}
