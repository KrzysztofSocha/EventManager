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
                    return time.Days.ToString() + " " + "dni temu";
                else
                    return "dzień temu";
            }
            else if (time.Hours > 0)
            {
                if (time.Hours > 1)
                    return time.Hours.ToString() + " " + "godz. temu";
                else
                    return "godzinę temu";
            }
            else if (time.Minutes > 5)
            {
                return time.Minutes.ToString() + " " + "minut temu";
            }
            return "przed chwilą";

        }
    }

}


