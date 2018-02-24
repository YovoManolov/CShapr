using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    static class UserData
    {
        private static List <User> testUsers = new List<User>();
        static public List<User> TestUsers
        {

            get { return testUsers; }
            set { }

        }

        public static User isUserPassCorrect(String username, String password)
        {
            foreach (User u in testUsers)
            {
                if (u.Username.Equals(username) && u.Password.Equals(password))
                {
                    return u;
                }
            }
            return null;
        }
        static private void ResetTestUserData()
        {
            testUsers.Add(new User("AdminName", "PassAdmin","11111",2, DateTime.Now,DateTime.MaxValue));
            testUsers.Add(new User("Student1","St1Pass", "22222", 5,DateTime.Now,DateTime.MaxValue));
            testUsers.Add(new User("Student2","St2Pass","33333", 5,DateTime.Now,DateTime.MaxValue)); 

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


        public static void SetUserActiveTo(String UserName, DateTime activeTo)
        {
            if (UserName != null)
            {

                foreach (User u in testUsers)
                {
                    if (u.Username.Equals(UserName))
                    {
                        u.activeTo = activeTo;
                        Logger.logActivity(Convert.ToString("Промяна на активност на " + u.Username));
                    }
                    else
                    {
                        Console.WriteLine("User not found in the database;");
                    }

                }
            }
            else
            {
                Console.WriteLine("Username is not a valid argument");
            }
        }


        public static void AssignUserRole(String UserName,UserRoles role)
        {

            if (UserName != null)
            {
                foreach (User u in testUsers)
                {
                    if (u.Username.Equals(UserName))
                    {
                        u.Role = Convert.ToInt32(role);

                        Logger.logActivity(Convert.ToString("Промяна на роля на " + u.Username));
                    }
                }
            }
            else
            {
                Console.WriteLine("Username is not a valid argument");
            }

        }


    }
}
