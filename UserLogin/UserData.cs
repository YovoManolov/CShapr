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

            User u = (from us in testUsers
                      where us.Username.Equals(username) &&  us.Password.Equals(password)
                      select us).First();
           if(u != null){

                    return u;
           }
           Console.WriteLine("User with such password or/and username was not found!");
           Console.ReadLine();
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


        public static void SetUserActiveTo(Int32 UserIndex, DateTime activeTo)
        {
             testUsers.ElementAt(UserIndex).activeTo = activeTo;
             Logger.logActivity(Convert.ToString("Промяна на активност на " + testUsers.ElementAt(UserIndex).Username));

        }


        public static void AssignUserRole(Int32 UserIndex,UserRoles role)
        {
             
             testUsers.ElementAt(UserIndex).Role = Convert.ToInt32(role);
             Logger.logActivity(Convert.ToString("Промяна на роля на " + testUsers.ElementAt(UserIndex).Username));
                  
        }

        static public Dictionary<string, int> AllUsersUsernames()
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            for (int i = 0; i < testUsers.Count; i++)
            {
                result.Add(testUsers.ElementAt(i).Username, i);
            }
            return result;
        }


    }
}
