namespace SchedulerClassLib;

public class GuardHelper
{
    public static void ValidateInput(Config config)
    {
        /* First Guard: StartDate is after current Date */
        if (config.StartDate > config.CurrentDate)
        {
            throw new Exception("StartDate is After current Date");
        }
        
        /* Second Guard: End date check */
        if (config.EndDate != null && config.CurrentDate > config.EndDate)
        {
            throw new Exception("Current Date is After End Date");
        }
    }
}