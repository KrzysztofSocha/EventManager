namespace EventManager.Helpers
{
    public static class DateHelper
    {
        public static string GetTaskTimeString(DateTime date)
        {
            var time = DateTime.Now.Subtract(date);
            if (time.Days > 0)
            {
                if (time.Days > 1)
                    return time.Days.ToString() + " " + "days ago";
                else
                    return "day ago";
            }
            else if (time.Hours > 0)
            {
                if (time.Hours > 1)
                    return time.Hours.ToString() + " " + "hours ago";
                else
                    return "hour ago";
            }
            else if (time.Minutes > 5)
            {
                return time.Minutes.ToString() + " " + "minutes ago";
            }
            return "just now";

        }
    }

}


