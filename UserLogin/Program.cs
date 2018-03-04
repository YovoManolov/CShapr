﻿using System;
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
            Console.WriteLine("Enter username: ");
            us.Username = Console.ReadLine();
            Console.WriteLine("Enter password: ");
            us.Password = Console.ReadLine();

            LoginValidation logVal = new LoginValidation(us.Username, us.Password, printError);


            User us1 = null;
            if (logVal.ValudateUserInput(ref us1))
            {
               
                Console.WriteLine("\n\nUsername :" + us1.Username + "\nPassword :" + us1.Password
                    + "\nFakNum :" + us1.FakNum + "\nRole :" + us1.Role);

                UserData.UserRoleOfCurrUser = us1.Role;

                Console.Write("\n\nCurrent user role from \"_currentUserRole\" is ");
                switch ((Int32)LoginValidation._currentUserRole)
                {
                    case (2):
                        Console.WriteLine("ADMIN");
                        callMenu(us1.Role);
                        break;
                    case (3):
                        Console.WriteLine("INSPECTOR");
                        callMenu(us1.Role);
                        break;
                    case (4):
                        Console.WriteLine("PROFESSOR");
                        callMenu(us1.Role);
                        break;
                    case (5):
                        Console.WriteLine("STUDENT");
                        callMenu(us1.Role);
                        break;
                    default:
                        Console.WriteLine("Something went wrong");
                        break;
                }

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
            Console.WriteLine("!!!" + errorMessage + "!!!");
        }

        public static void callMenu(int uR)
        {
            List<RoleRights> currUsRR =
                            RightsGranted.getRightsByRole((UserRoles)uR);
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
