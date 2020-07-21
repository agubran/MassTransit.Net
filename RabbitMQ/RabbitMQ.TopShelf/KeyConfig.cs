using System;
using System.Configuration;

namespace RabbitMQ.TopShelf
{
   public static class KeyConfig
    {
        public static int WindowsServiceTimerIntervalMinutes
        {
            get
            {
                var result = ConfigurationManager.AppSettings["WindowsServiceTimerIntervalMinutes"];
                if (String.IsNullOrEmpty(result))
                    return 5;
                return Int32.Parse(result);
            }
        }

        public static bool TestEnabled
        {
            get
            {
                var result = ConfigurationManager.AppSettings["TestEnabled"];
                if (String.IsNullOrEmpty(result))
                    return false;
                return bool.Parse(result);
            }
        }
    }
}
