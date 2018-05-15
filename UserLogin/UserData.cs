using PS_38_Yovo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public static class UserData
    {
        private static List<User> testUsers = new List<User>()
        {
            new User("AdminName", "AdminPass", "11111", 1, DateTime.Now, DateTime.MaxValue),
            new User("Inspector", "InspPass", "44444", 2, DateTime.Now, DateTime.MaxValue),
            new User("Professor", "ProfPass", "33333", 3, DateTime.Now, DateTime.MaxValue),
            new User("Student2", "St2Pass", "1231233", 4, DateTime.Now, DateTime.MaxValue)
        };


        public static int UserRoleOfCurrUser;
        public static  List<User> TestUsers
        {
            get {   
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
        
        public static User FindUserByUserName(String Username)
        {
            UserContext context = new UserContext();
            User usr = (from u in UserData.TestUsers where u.Username == Username select u).First();
            if (usr != null)
            {
                return usr;
            }
            else
            {
                return null;
            }
        }

        public static Dictionary<string, int> AllUsersUsernames()
        {
            Dictionary<string, int> result = new Dictionary<string, int>();

            int userCount = UserData.TestUsers.Count;

            for (int i = 0; i < testUsers.Count; i++)
            {
                result.Add(testUsers.ElementAt(i).Username, i);
            }
            return result;
        }

        public static void assignRoleByUsername(String Username)
        {
            Console.WriteLine("\nВъведете новата роля за избрания от Вас потребител,използвайки една от следните думи: ");
            Console.WriteLine(" ANONYMOS, ADMIN, INSPECTOR, PROFESSOR, STUDENT");
            Console.Write("Нова роля: ");
            String newRole = Console.ReadLine().Trim().ToUpper();

            UserRoles newRoleToAssign = (UserRoles)Enum.Parse(typeof(UserRoles), newRole);
            bool wasTheRoleChanged = false;

            UserContext context = new UserContext();
            User usr = FindUserByUserName(Username);

                if(usr != null)
                {
                    //RR means RoleRights
                    List<RoleRights> currUsRR = RightsGranted.getRightsByRole((UserRoles)UserRoleOfCurrUser);
                    //can edit users in handled in main menu
                    if ((UserRoles)UserRoleOfCurrUser == UserRoles.STUDENT
                                            && (!currUsRR.Contains(RoleRights.CanEditStudents)))
                    {
                        Program.printError("Нямате права да редактирате профили на студенти");
                        Program.callMenu(UserRoleOfCurrUser);
                    }
                    else
                    {
                        if (usr.Role != Convert.ToInt32(newRoleToAssign))
                        {
                            usr.Role = (int)newRoleToAssign;
                            context.SaveChanges();
                            wasTheRoleChanged = true;

                            String result = Convert.ToString("Ролята на " + usr.Username + "беше променена!\n");
                            Logger.logActivity(result);
                            Console.WriteLine(result);

                            Program.callMenu(usr.Role);
                        }
                        else
                        {
                            Program.printError("Ролята, която искате да приложите, е текущата роля на"
                                + "потрбителя, когото сте избрали.\n Моля, изберете друга роля");
                        }
                    }
                }
                else
                {
                    Program.printError("Потребител с такова потребителско име не съществува! Моля, опитайте отново");
                    Program.callMenu(usr.Role);
                }
            
            if (wasTheRoleChanged != true)
            {
                Console.WriteLine("Ролята, която избрахте не беше намерена в списъка с възможни роли!\n\n");
                Program.callMenu(UserRoleOfCurrUser);
            }
        }

        public static void chngAtivPerByUsername(String Username)
        {

            User userToChange = FindUserByUserName(Username);
            //RR means RoleRights
            List<RoleRights> currUsRR = RightsGranted.getRightsByRole((UserRoles)UserRoleOfCurrUser);
          
            if ((UserRoles)userToChange.Role == UserRoles.STUDENT && (!currUsRR.Contains(RoleRights.CanEditStudents)))
            {
                Program.printError("Нямате права да редактирате профили на студенти");
                Program.callMenu(UserRoleOfCurrUser);
            }
            else
            {
                Console.WriteLine("Въведете края на активния период за избрания от Вас потребител : ");
                String year, month, day;
                Console.Write("Въведете година : ");
                year = Console.ReadLine();
                Console.Write("Въведете месец : ");
                month = Console.ReadLine();
                Console.Write("Въведете ден : ");
                day = Console.ReadLine();

                DateTime dt = new DateTime(Convert.ToInt32(year),
                                             Convert.ToInt32(month),
                                             Convert.ToInt32(day));

                userToChange.ActiveTo = dt;
                Logger.logActivity(Convert.ToString("Промяна на активност на " + userToChange.Username));

                String result = "Периодът на активност на " + Username + "беше променен до " + dt.ToString();
                Logger.logActivity(result);
                Console.WriteLine(result);

                Program.callMenu(UserRoleOfCurrUser);
            }
        }


        //static private void ResetTestUserData()
        //{
        //    testUsers.Clear();
        //    testUsers.Add();
        //    testUsers.Add(new User("Student1", "St1Pass", "22222", 4, DateTime.Now, DateTime.MaxValue));

        //}


    }
}
