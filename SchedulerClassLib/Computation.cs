namespace SchedulerClassLib;

public static class Computation
{
    public static Tuple<DateTime, string, Dictionary<DateTime,List<TimeOnly>>> ComputeNextDate(Config config)
    {
        DateTime currentExecutionDate = config.CurrentDate;
        DateTime nextDate = default;
        var recurringTimeInterval = new Dictionary<DateTime, List<TimeOnly>>();
        var description = "";
        
        if (config.OccurenceType == Occurence.Recurring)
        {
            var timeIntervals = new Dictionary<DateTime,TimeOnly>();
            GuardHelper.ValidateInput(config);
     
            nextDate = config.StartDate > config.CurrentDate
                ? config.StartDate
                : currentExecutionDate.AddDays(config.OccursEvery);
            GuardHelper.ValidateMaxHoursEntered(config.EveryHours);
            GuardHelper.CheckIfStartTimeIsBeforeEndTime(startTime:config.StartTime, endTime:config.EndTime);
            
            recurringTimeInterval.Add(nextDate,[config.StartTime]);
            var startTime = config.StartTime;
               
            while ( startTime < config.EndTime)
            {
                startTime = startTime.AddHours(config.EveryHours);
                if (startTime > config.EndTime)
                    break;
                recurringTimeInterval[nextDate].Add(startTime);
            }
         
            description = $"Schedule will be used starting on {config.StartDate}";
        }
        
        else if (config.OccurenceType == Occurence.Once)
        {
            GuardHelper.ValidateDateForOneTime(config);
            var date = DateOnly.FromDateTime(config.ConfDateTime);
            var time = TimeOnly.FromDateTime(config.ConfDateTime);
            nextDate = config.ConfDateTime;
            description = $"Schedule will be used on {date} at {time} starting on {config.StartDate}";
        }
        return Tuple.Create(nextDate, description, recurringTimeInterval)!;
    }
    
 
}




