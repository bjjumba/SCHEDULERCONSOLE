namespace SchedulerClassLib;

public class GuardHelper
{
    public static void ValidateInput(Config config)
    {
        /* Second Guard: End date check */
        if (config.EndDate != null && config.CurrentDate > config.EndDate)
        {
            throw new Exception("Current Date is After End Date");
        }
    }
}