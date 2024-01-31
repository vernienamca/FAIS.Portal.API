using System;

namespace FAIS.ApplicationCore.Helpers
{
    /// <summary>
    /// The helper class for date and time.
    /// </summary>
    public static class DateTimeHelpers
    {
        /// <summary>
        /// Gets the greeting based on the time of day.
        /// </summary>
        public static string GetGreetings()
        {
            var now = DateTime.Now;
            string greeting = "Hello";

            if (now.Hour >= 5 && now.Hour < 12)
                greeting = "Good morning";
            else if (now.Hour >= 12 && now.Hour < 16)
                greeting = "Good afternoon";
            else if (now.Hour >= 16)
                greeting = "Good evening";

            return greeting;
        }
    }
}
