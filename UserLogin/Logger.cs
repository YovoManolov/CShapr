using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserLogin
{
    public static class Logger
    {
        private static List<String> currentSessionActivities = new List<String>();

        static public void logActivity(String activity)
        {

            string activityLine = DateTime.Now + "\t;" +
            LoginValidation._currentUserUsername + "\t;" +
            LoginValidation._currentUserRole + "\t;" + activity;

            currentSessionActivities.Add(activityLine);

            if (File.Exists("test.txt") == true)
            {
                File.AppendAllText("text.txt", Environment.NewLine + activityLine);
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