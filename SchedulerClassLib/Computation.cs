namespace SchedulerClassLib;

public static class Computation
{
    public static Tuple<DateOnly, string> ComputeNextDate(Config config)
    {
        DateOnly currentExecutionDate = config.CurrentDate;
        DateOnly nextDate = default;
        var description = "";
    
        GuardHelper.ValidateInput(config);
        
        if (config.StartDate > config.CurrentDate)
        {
            nextDate = config.StartDate;
        }
        
        if (config.OccurenceType == Occurence.Recurring)
        {
            if (nextDate == default)
            {
                nextDate = currentExecutionDate.AddDays(config.OccursEvery);
            }
            description = $"Schedule will be used starting on {config.StartDate}";
        }
        
        else if (config.OccurenceType == Occurence.Once)
        {
            DateOnly date = DateOnly.FromDateTime(config.ConfDateTime);
            TimeOnly time = TimeOnly.FromDateTime(config.ConfDateTime);
            
            if (nextDate == default)
            {
                nextDate = currentExecutionDate.AddDays(config.OccursEvery);
            }
            description = $"Schedule will be used on {date} at {time} starting on {config.StartDate}";
        }
        return Tuple.Create(nextDate, description)!;
    }
    
    // public Tuple<DateOnly, string> ComputeNextDate(Config config)
    // {
    //     var result = calculateNextDate(config);
    //     return result;
    // }
}




