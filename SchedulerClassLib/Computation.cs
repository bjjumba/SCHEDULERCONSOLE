namespace SchedulerClassLib;

public static class Computation
{
    public static Tuple<DateTime, string> ComputeNextDate(Config config)
    {
        DateTime currentExecutionDate = config.CurrentDate;
        DateTime nextDate = default;
        var description = "";
        
        if (config.OccurenceType == Occurence.Recurring)
        {
            GuardHelper.ValidateInput(config);
            nextDate = config.StartDate > config.CurrentDate ? config.StartDate : currentExecutionDate.AddDays(config.OccursEvery);
            description = $"Schedule will be used starting on {config.StartDate}";
        }
        
        else if (config.OccurenceType == Occurence.Once)
        {
            GuardHelper.ValidateDateForOneTime(config);
            DateOnly date = DateOnly.FromDateTime(config.ConfDateTime);
            TimeOnly time = TimeOnly.FromDateTime(config.ConfDateTime);
            nextDate = config.StartDate > config.CurrentDate ? config.StartDate : currentExecutionDate.AddDays(config.OccursEvery);
            description = $"Schedule will be used on {date} at {time} starting on {config.StartDate}";
        }
        return Tuple.Create(nextDate, description)!;
    }
    
 
}




