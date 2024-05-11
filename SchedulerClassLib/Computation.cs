namespace SchedulerClassLib;

public class Computation
{
    Func<Config, Tuple<DateOnly, string>> calculateNextDate = (Config config) =>
    { 
        var occurenceType = config.OccurenceType;
        var currentDate = config.CurrentDate;
        DateOnly nextDate = default;
        var description = "";
    
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
  
        
        if (occurenceType == Occurence.Recurring)
        {
            nextDate = currentDate.AddDays(1);
            description = $"Schedule will be used starting on {config.StartDate}";
        }
        
        else if (occurenceType == Occurence.Once)
        {
            DateOnly date = DateOnly.FromDateTime(config.ConfDateTime);
            TimeOnly time = TimeOnly.FromDateTime(config.ConfDateTime);
            nextDate = currentDate.AddDays(+1);
            description = $"Schedule will be used on {date} at {time} starting on {config.StartDate}";
        }
        return Tuple.Create(nextDate, description)!;
    };
    public Tuple<DateOnly, string> ComputeNextDate(Config config)
    {
        var result = calculateNextDate(config);
        return result;
    }
}




