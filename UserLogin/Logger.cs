using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserLogin
{
    static class Logger
    {
        private static List<String> currentSessionActivities = new List<String>();

        static public void logActivity(String activity)
        {

            string activityLine = DateTime.Now + ";" +
                LoginValidation.currentUserUsername + ";" +
                LoginValidation.currentUserRole + ";" + activity;

            currentSessionActivities.Add(activityLine);
        }    

    }
}