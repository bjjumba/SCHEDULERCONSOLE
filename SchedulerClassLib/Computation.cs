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
            
            if (config.Occurs == OccurenceFrequency.Weekly)
            {
                nextDate = config.StartDate > config.CurrentDate
                    ? config.StartDate
                    : currentExecutionDate.AddDays(config.OccursDays);
                
                ///This has been put in function ComputeDailyFrequency
                // GuardHelper.ValidateMaxHoursEntered(config.EveryHours);
                // GuardHelper.CheckIfStartTimeIsBeforeEndTime(startTime:config.StartTime, endTime:config.EndTime);
                //
                // recurringTimeInterval.Add(nextDate,[config.StartTime]);
                // var startTime = config.StartTime;
                //
                // while ( startTime < config.EndTime)
                // {
                //     startTime = startTime.AddHours(config.EveryHours);
                //     if (startTime > config.EndTime)
                //         break;
                //     recurringTimeInterval[nextDate].Add(startTime);
                // }
            }
            
            else if (config.Occurs == OccurenceFrequency.Daily)
            {
                nextDate = config.StartDate > config.CurrentDate
                    ? config.StartDate
                    : currentExecutionDate.AddDays(config.OccursDays);

                ComputeDailyFrequency(config.StartTime, config.EndTime, config.EveryHours, recurringTimeInterval, nextDate);
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
    
    //Function to calculate daily frequency for recurring
    public static void ComputeDailyFrequency(TimeOnly startingTime, TimeOnly endingTime, int hours, Dictionary<DateTime, List<TimeOnly>> dictionary, DateTime date)
    {
        var recurringTimeInterval = dictionary;
        var nextDate = date;
        var startTime = startingTime;
        var endTime = endingTime;
        var everyHours = hours;
        
        GuardHelper.ValidateMaxHoursEntered(everyHours);
        GuardHelper.CheckIfStartTimeIsBeforeEndTime(startTime:startTime, endTime:endTime);
            
        recurringTimeInterval.Add(nextDate,[startTime]);
        var newTime = startTime;
               
        while ( newTime < endTime)
        {
            newTime = newTime.AddHours(everyHours);
            if (newTime > endTime)
                break;
            recurringTimeInterval[nextDate].Add(newTime);
        }
    }
    
}




