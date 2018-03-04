using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    static class UserData
    {
        private static List<User> testUsers = new List<User>();
        public static int UserRoleOfCurrUser;

        static public List<User> TestUsers
        {

            get {
                ResetTestUserData();
                return testUsers;
            }
            set { }

        }

        public static User isUserPassCorrect(String username, String password)
        {
            User u = (from us in testUsers
                      where us.Username.Equals(username) && us.Password.Equals(password)
                      select us).FirstOrDefault();

            if (u != null)
            {
                return u;
            }
            else
            {
                return null;
            }
        }
        static private void ResetTestUserData()
        {
            testUsers.Add(new User("AdminName", "AdminPass", "11111", 2, DateTime.Now, DateTime.MaxValue));
            testUsers.Add(new User("Student1", "St1Pass", "22222", 5, DateTime.Now, DateTime.MaxValue));
            testUsers.Add(new User("Student2", "St2Pass", "33333", 5, DateTime.Now, DateTime.MaxValue));

        }

        public static User FindUserByUserName(String Username)
        {
            foreach (User u in testUsers)
            {
                if (u.Username.Equals(Username))
                {
                    return u;
                }

            }
            return null;
        }

       
        public static Dictionary<string, int> AllUsersUsernames()
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            for (int i = 0; i < testUsers.Count; i++)
            {
                result.Add(testUsers.ElementAt(i).Username, i);
            }
            return result;
        }

        public static void assignRoleByUsername(String Username)
        {

            Console.WriteLine("\nВъведете новата роля за избрания от Вас потребител,използвайки една от следните думи: ");
            Console.WriteLine("ANONYMOS, ADMIN, INSPECTOR, PROFESSOR, STUDENT ");
            Console.Write("Нова роля: ");
            String newRole = Console.ReadLine().Trim().ToUpper();

            UserRoles newRoleToAssign = (UserRoles)Enum.Parse(typeof(UserRoles), newRole);
            bool wasTheRoleChanged = false;
            foreach (UserRoles userRole in Enum.GetValues(typeof(UserRoles)))
            {
                //след като новата роля е намерена в енумерацията логиката 
                // за промяна на ролята започва да работи
                if (userRole == newRoleToAssign)
                {
                    wasTheRoleChanged = true;
                    int userIndex = AllUsersUsernames()[Username];
                    //RR means RoleRights
                    List<RoleRights> currUsRR = RightsGranted.getRightsByRole((UserRoles)UserRoleOfCurrUser);

                    //can edit users in handled in main menu
                    if ((UserRoles)testUsers.ElementAt(userIndex).Role == UserRoles.STUDENT && (!currUsRR.Contains(RoleRights.CanEditStudents)))
                    {
                        Program.printError("Нямате права да редактирате профили на студенти");
                        Program.callMenu(UserRoleOfCurrUser);
                    }
                    else
                    {
                        if (testUsers.ElementAt(userIndex).Role != Convert.ToInt32(newRoleToAssign))
                        {
                            testUsers.ElementAt(userIndex).Role = Convert.ToInt32(newRoleToAssign);
                            String result = Convert.ToString("Ролята на " + testUsers.ElementAt(userIndex).Username + "беше променена!\n");
                            Logger.logActivity(result);
                            Console.WriteLine(result);

                            Program.callMenu(UserRoleOfCurrUser);
                        }
                        else
                        {
                            Program.printError("The role you chose is the current role of the user.\n Please select another one! ");
                        }
                    }
                    
                }
            }
            if (wasTheRoleChanged != true)
            {
                Console.WriteLine("The role you have chosen was not found in the list of roles !\n\n");
                Program.callMenu(UserRoleOfCurrUser);
            }
        }

        public static void chngAtivPerByUsername(String Username)
        {

            int userIndex = AllUsersUsernames()[Username];
            //RR means RoleRights
            List<RoleRights> currUsRR = RightsGranted.getRightsByRole((UserRoles)UserRoleOfCurrUser);

            if ((UserRoles)testUsers.ElementAt(userIndex).Role == UserRoles.STUDENT && (!currUsRR.Contains(RoleRights.CanEditStudents)))
            {
                Program.printError("Нямате права да редактирате профили на студенти");
                Program.callMenu(UserRoleOfCurrUser);
            }
            else
            {
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

                testUsers.ElementAt(userIndex).activeTo = dt;
                Logger.logActivity(Convert.ToString("Промяна на активност на " + testUsers.ElementAt(userIndex).Username));

                String result = "Периодът на активност на " + Username + "беше променен до " + dt.ToString();
                Logger.logActivity(result);
                Console.WriteLine(result);

                Program.callMenu(UserRoleOfCurrUser);
            }
        }
    }
}
