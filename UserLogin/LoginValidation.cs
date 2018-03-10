using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public class LoginValidation
    {
        public static UserRoles _currentUserRole ;
        public static String _currentUserUsername;
        private String Username;
        private String Password;
        private String ErrorMessage;

        public delegate void ActionOnError(String errorMsg);    
        private ActionOnError actionOnError ;

        public LoginValidation(String username, String password, ActionOnError actionOnError)
        {
            this.Username = username;
            this.Password = password;
            this.actionOnError = actionOnError;
        }

        public static String currentUserUsername
        {
            get;
            private set;
        }

        public static UserRoles currentUserRole
        {
            get;
            private set;
        }                                       

        public bool ValudateUserInput(ref User user)
        {
            List<User> testUsers = UserData.TestUsers;

            Boolean emptyUserName;
            emptyUserName = Username.Equals(String.Empty);
            if (emptyUserName == true)
            {
                _currentUserRole = UserRoles.ANONYMOS;
                ErrorMessage = "Не е посочено потребителско име\n";
                Program.printError(ErrorMessage);
                Console.ReadLine();
                actionOnError(ErrorMessage);
                return false;
            }

            //------------------------------------
            Boolean emptyPassword;
            emptyPassword = Password.Equals(String.Empty);
            if (emptyPassword == true)
            {
                _currentUserRole = UserRoles.ANONYMOS;
                ErrorMessage = "Не е посочена парола\n";
                Program.printError(ErrorMessage);
                Console.ReadLine();
                return false;
            }

            //------------------------------------
            Boolean userNameAndPasswordMinLenght;


            userNameAndPasswordMinLenght = (Username.Length < 5 || Password.Length < 5);
            if (userNameAndPasswordMinLenght == true)
            {
                _currentUserRole = UserRoles.ANONYMOS;
                ErrorMessage = "Дължината на потребителското име или паролата е по-малка от 5 символа\n";
                Program.printError(ErrorMessage);
                Console.ReadLine();
                return false;
            }   
            
            user = UserData.isUserPassCorrect(Username, Password);
            if (user != null)
            {
                _currentUserRole = (UserRoles)user.Role;
            }
            else
            {
                _currentUserRole = UserRoles.ANONYMOS;
                ErrorMessage = "Не беше намерен потребител с такова потребителско име или парола !";
                Program.printError(ErrorMessage);
                return false;
            }

            _currentUserUsername = user.Username;
            Logger.logActivity(Convert.ToString("Успешен login"));
            return true;
        }
    }
}
