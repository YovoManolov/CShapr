using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using UserLogin;

namespace PS_38_Yovo
{
    class UserContext : DbContext
    {
        public UserContext() : base(Properties.Settings.Default.DbConnect) { }
        public DbSet<User> Users { get; set; }

        private static List<User> GetUsers()
        {
            UserContext context = new UserContext();
            List<User> users = context.Users.ToList();
            return users;
        }
    }
}
