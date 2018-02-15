using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    class LoginValidation
    {
        public static UserRoles _currentUserRole ;
        private String Username;
        private String Password;
        private String ErrorMessage;

        public LoginValidation(String username, String password)
        {
            this.Username = username;
            this.Password = password;
        }


        public UserRoles currentUserRole
        {
            get;
            private set;
            
        }

        public bool ValudateUserInput(out User user)
        {
            User[] testUsers = UserData.TestUsers;

            _currentUserRole = (UserRoles)user.Role;

            Boolean emptyUserName;
            emptyUserName = Username.Equals(String.Empty);
            if (emptyUserName == true)
            {
                ErrorMessage = "Не е посочено потребителско име\n";
                Console.WriteLine(ErrorMessage);
                return false;
            }

            Boolean emptyPassword;
            emptyPassword = Password.Equals(String.Empty);
            if (emptyPassword == true)
            {
                ErrorMessage = "Не е посочена парола\n";
                Console.WriteLine(ErrorMessage);
                return false;
            }

            Boolean userNameAndPasswordMinLenght;


            userNameAndPasswordMinLenght = (Username.Length < 5 || Password.Length < 5);
            if (userNameAndPasswordMinLenght == true)
            {
                ErrorMessage = "Дължината на потребителското име или паролата е по-малка от 5 символа\n";
                Console.WriteLine(ErrorMessage);
                return false;
            }
            return true;
        }

    }
}
