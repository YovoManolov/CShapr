using System;
using System.IO;
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

            if (File.Exists("test.txt") == true)
            {
                File.AppendAllText("text.txt", activityLine);
            } 
        }    

        public static void GetCurrentSessionActivities(String filter)
        {
            StringBuilder sb = new StringBuilder();
            List<string> filteredActivities = (from activity in currentSessionActivities
                                               where activity.Contains(filter)
                                               select activity).ToList();

            foreach(var action in filteredActivities){
                sb.Append(action);
            }
            Console.WriteLine(sb.ToString());
        }

    }
}