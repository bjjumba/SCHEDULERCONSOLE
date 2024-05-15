using SchedulerClassLib;

namespace SchedulerTest;

public class DailyFrequencyGuardTests
{
    //Daily Frequency Tests
    [Fact]
    public void EndTime_Encroaches_Next_Day_After_Recurring_Interval()
    {
        
    }

    [Fact]
    public void Next_Execution_Time_IsAfter_EndTime()
    {
        
    }

    [Fact]
    public void Start_Time_Is_Greater_Than_EndTime()
    {
        Assert.Throws<Exception>(() => Computation.ComputeNextDate(new Config
        {
            CurrentDate = new DateTime(2020, 1, 4),
            OccurenceType = Occurence.Recurring,
            OccursEvery = 1,
            StartDate = new DateTime(2020, 1, 1),
            EndDate = new DateTime(2020, 1, 8),
            StartTime = new TimeOnly(4,0,0),
            EndTime = new TimeOnly(2,0,0),
        }));
        
    }
}