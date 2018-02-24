using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    class User
    {
        public String Username;
        public String Password;
        public String FakNum;
        public Int32 Role;
        public DateTime timeOfCreation;
        public DateTime activeTo;

        public User(String Username,String Password,String FakNum,Int32 Role,DateTime timeOfCreation,
           DateTime activeTo)
        {
            this.Username = Username;
            this.Password = Password;
            this.FakNum = FakNum;
            this.Role = Role;
            this.timeOfCreation = timeOfCreation;
            this.activeTo = activeTo;
        }

        public User() {  }
    }
}
