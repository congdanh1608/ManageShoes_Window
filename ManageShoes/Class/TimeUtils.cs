using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageShoes.Class
{
    class TimeUtils
    {
        public static DateTime convertMiliToDateTime(long milliseconds){
            return new DateTime(milliseconds); 
        }

        public static double convertDateTimeToMili(DateTime dateTime)
        {
            return (DateTime.Now - dateTime).TotalMilliseconds;
        }

        public static String getCurrentDate()   //dd-mm-yyyy
        {
            String date = null;
            DateTime datetime = DateTime.Today;
            date = datetime.ToString("dd/MM/yyyy");
            return date;
        }

        public static double getCurrentTimeInMilisecond()   //dd-mm-yyyy
        {
            return DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        }
    }
}
