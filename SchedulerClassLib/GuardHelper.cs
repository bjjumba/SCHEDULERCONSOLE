namespace SchedulerClassLib;

public class GuardHelper
{
    public static void ValidateInput(Config config)
    {
        /* Second Guard: End date check */
        if (DateTime.Compare(config.CurrentDate, config.EndDate)>0)
        {
            throw new Exception("Current Date is After End Date");
        }
    }
    
    /******Once Guard******/

    public static void ValidateDateForOneTime(Config config)
    {
        if (config.ConfDateTime < DateTime.Now)
            throw new Exception("Date and Time must be in the future");
    }
}