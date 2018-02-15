using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    static class UserData
    {

        static private User[] testUsers = new User[3];

        static public User[] TestUsers
        {

            get
            {
                DefaultUserData();
                return testUsers;
            }
            set { }

        }

        public static User isUserPassCorrect(String username ,String password)
        {
            for (int i = 0; i < testUsers.Length; i++)
            {
                if(testUsers[i].Username.Equals(username) && testUsers[i].Password.Equals(password))
                {
                    return testUsers[i];
                }
            }
            return null;
        }
        static private void DefaultUserData()
        {
            testUsers[0].Username = "AdminName";
            testUsers[0].Password = "PassAdmin";
            testUsers[0].FakNum = "11111";
            testUsers[0].Role = 1;

            testUsers[1].Username = "Student1";
            testUsers[1].Password = "St1Pass";
            testUsers[1].FakNum = "22222";
            testUsers[1].Role = 5;

            testUsers[2].Username = "Student2";
            testUsers[2].Password = "St2Pass";
            testUsers[2].FakNum = "33333";
            testUsers[3].Role = 5;

        }
    }
}
