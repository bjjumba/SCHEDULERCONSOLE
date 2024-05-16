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
                    : currentExecutionDate;
                
                GuardHelper.ValidateMaxHoursEntered(config.EveryHours);
                GuardHelper.CheckIfStartTimeIsBeforeEndTime(startTime:config.StartTime, endTime:config.EndTime);
                
                var myDates = new List<DateTime> ();
                var addNWeeks = nextDate.AddDays(config.Weeks);
                
                for (var i = 0; i < 7; i++)
                {
                   myDates.Add(addNWeeks.AddDays(i));
                }
                
                foreach (var day in myDates)
                {
                    foreach (var selectedDate in config.SelectedWeekDays)
                    {
                        if ((int)selectedDate == (int)day.DayOfWeek)
                        {
                            ComputeDailyFrequency(config.StartTime, config.EndTime, config.EveryHours, recurringTimeInterval, day);
                        }
                    }
                }
                
            }
            
            else if (config.Occurs == OccurenceFrequency.Daily)
            {
                nextDate = config.StartDate > config.CurrentDate
                    ? config.StartDate
                    : currentExecutionDate.AddDays(config.OccursDays);
                
                GuardHelper.ValidateMaxHoursEntered(config.EveryHours);
                GuardHelper.CheckIfStartTimeIsBeforeEndTime(startTime:config.StartTime, endTime:config.EndTime);
                
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




