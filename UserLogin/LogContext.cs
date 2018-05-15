using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using UserLogin;

namespace PS_38_Yovo.UserLogin
{
    class LogContext: DbContext
    {
        public LogContext() : base(Properties.Settings.Default.DbConnect) { }
        public DbSet<Log> Logs { get; set; }
        
        public void addLog(String log)
        {
            LogContext context = new LogContext();
            context.Logs.Add(new Log(log));
            context.SaveChanges();
        }
    }
    
}
