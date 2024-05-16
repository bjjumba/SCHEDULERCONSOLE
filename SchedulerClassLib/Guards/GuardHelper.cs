namespace SchedulerClassLib;

public class GuardHelper
{
    public static void ValidateInput(Config config)
    {
        /* Second Guard: End date check */
        if (config.CurrentDate > config.EndDate)
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
    
    /*Daily Ocurrence*/

    public static void CheckIfStartTimeIsBeforeEndTime(TimeOnly startTime, TimeOnly endTime)
    {
        if (startTime > endTime)
            throw new Exception("StartTime is after EndTime");
    }
    
    /******Maximum EveryHours Guard******/
    public static void ValidateMaxHoursEntered(int hours)
    {
        if (hours > 23)
            throw new Exception("Hours entered are out of bound");
    }
}