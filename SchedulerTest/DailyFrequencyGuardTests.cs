using SchedulerClassLib;

namespace SchedulerTest;

public class DailyFrequencyGuardTests
{
    //Daily Frequency Tests
    // [Fact]
    // public void EndTime_Encroaches_Next_Day_After_Recurring_Interval()
    // {
    //     
    // }

    [Fact]
    public void Next_Execution_Time_IsAfter_EndTime()
    {
        
    }

    [Fact]
    public void Start_Time_Is_Greater_Than_EndTime()
    {
        Assert.Throws<Exception>(() => Computation.ComputeNextDate(new Config
        {
            CurrentDate = new DateTime(2020, 1, 9),
            OccurenceType = Occurence.Recurring,
            OccursDays = 1,
            StartDate = new DateTime(2020, 1, 1),
            EndDate = new DateTime(2020, 1, 8),
            StartTime = new TimeOnly(4, 0, 0),
            EndTime = new TimeOnly(2, 0, 0)
        }));
        
    }
    
    [Fact]
    public void EveryHours_Is_GreaterThan_23()
    {
     
        Assert.Throws<Exception>(() => Computation.ComputeNextDate(new Config
        {
            EveryHours = 24
        }));
 
    }
}