namespace SchedulerTest;
using SchedulerClassLib;

public class RecurringTest
{
    [Fact]
    public void CurrentDate_Is_After_StartDate()
    {
        //Arrange
        var expectedDate = new DateTime(2020, 1, 5);
        
        //Act
        var result = Computation.ComputeNextDate(new Config
        {
            CurrentDate = new DateTime(2020, 1, 4),
            OccurenceType = Occurence.Recurring,
            Occurs = OccurenceFrequency.Daily,
            OccursDays = 1,
            StartDate = new DateTime(2020, 1, 1),
            EndDate = new DateTime(2020, 1, 8),
        });
        
        //Assert
        Assert.Equal(expectedDate, result.Item1);
    }
    [Fact]
    public void CurrentDate_Is_Before_StartDate()
    {
        //Arrange
        var expectedDate = new DateTime(2020, 1, 4);
            
        //Act
        var result = Computation.ComputeNextDate(new Config
        {
            CurrentDate = new DateTime(2020, 1, 1),
            OccurenceType = Occurence.Recurring,
            Occurs = OccurenceFrequency.Daily,
            OccursDays = 1,
            StartDate = new DateTime(2020, 1, 4),
            EndDate = new DateTime(2020, 1, 8),
        });
        
        //Assert
        Assert.Equal(expectedDate, result.Item1);
    }

    [Fact]
    public void Recurring_With_Hourly_Interval_And_CurrentDate_Is_Before_StartDate()
    {
        var expectedResult = new Dictionary<DateTime, List<TimeOnly>>
        {
            {
                new DateTime(2020,1,4),
                [
                    new TimeOnly(4,0,0),
                    new TimeOnly(6,0,0),
                    new TimeOnly(8,0,0)
                ]
            }
        };

        //Computation
        var result = Computation.ComputeNextDate(new Config
        {
            CurrentDate = new DateTime(2020, 1, 1),
            OccurenceType = Occurence.Recurring,
            Occurs = OccurenceFrequency.Daily,
            OccursDays = 1,
            StartDate = new DateTime(2020, 1, 4),
            EndDate = new DateTime(2020, 1, 8),
            StartTime = new TimeOnly(4, 0, 0),
            EndTime = new TimeOnly(8, 0, 0),
            EveryHours = 2
        });
        
        //Assert
        
        Assert.Equal(expectedResult, result.Item3);
    }
    
    [Fact]
    public void Recurring_With_Hourly_Interval_And_CurrentDate_Is_After_StartDate()
    {
        var expectedResult = new Dictionary<DateTime, List<TimeOnly>>
        {
            {
                new DateTime(2020,1,6),
                [
                    new TimeOnly(4,0,0),
                    new TimeOnly(6,0,0),
                    new TimeOnly(8,0,0)
                ]
            }
        };

        //Computation
        var result = Computation.ComputeNextDate(new Config
        {
            CurrentDate = new DateTime(2020, 1, 5),
            OccurenceType = Occurence.Recurring,
            Occurs = OccurenceFrequency.Daily,
            OccursDays = 1,
            StartDate = new DateTime(2020, 1, 1),
            EndDate = new DateTime(2020, 1, 8),
            StartTime = new TimeOnly(4, 0, 0),
            EndTime = new TimeOnly(8, 0, 0),
            EveryHours = 2
        });
        
        //Assert
        
        Assert.Equal(expectedResult, result.Item3);

    }
    
    [Fact]
    public void Recurring_With_Hourly_Interval_And_Next_Execution_Time_Exceeds_EndTime()
    {
        var expectedResult = new Dictionary<DateTime, List<TimeOnly>>
        {
            {
                new DateTime(2020,1,6),
                [
                    new TimeOnly(4,0,0),
                    new TimeOnly(6,0,0),
                    new TimeOnly(8,0,0)
                ]
            }
        };

        //Computation
        var result = Computation.ComputeNextDate(new Config
        {
            CurrentDate = new DateTime(2020, 1, 5),
            OccurenceType = Occurence.Recurring,
            Occurs = OccurenceFrequency.Daily,
            OccursDays = 1,
            StartDate = new DateTime(2020, 1, 1),
            EndDate = new DateTime(2020, 1, 8),
            StartTime = new TimeOnly(4, 0, 0),
            EndTime = new TimeOnly(9, 0, 0),
            EveryHours = 2
        });
        
        //Assert
        
        Assert.Equal(expectedResult, result.Item3);
    }

    [Fact]
    public void Recurring_With_Weekly_Ocurrence()
    {
        var expectedResult = new Dictionary<DateTime, List<TimeOnly>>
        {
            {
                new DateTime(2024,6,17),
                [
                    new TimeOnly(4,0,0),
                    new TimeOnly(6,0,0),
                    new TimeOnly(8,0,0)
                ]
            },
            {
                new DateTime(2024,6,20),
                [
                    new TimeOnly(4,0,0),
                    new TimeOnly(6,0,0),
                    new TimeOnly(8,0,0)
                ]
            },
            {
                new DateTime(2024,6,21),
                [
                    new TimeOnly(4,0,0),
                    new TimeOnly(6,0,0),
                    new TimeOnly(8,0,0)
                ]
            }

        };
        var result = Computation.ComputeNextDate(new Config
        {
            CurrentDate = new DateTime(2024, 6, 3),
            OccurenceType = Occurence.Recurring,
            Occurs = OccurenceFrequency.Weekly,
            OccursDays = 1,
            StartDate = new DateTime(2024, 5, 14),
            EndDate = new DateTime(2024, 8, 20),
            StartTime = new TimeOnly(4, 0, 0),
            EndTime = new TimeOnly(9, 0, 0),
            EveryHours = 2,
            SelectedWeekDays = new Days[] { Days.Monday, Days.Thursday, Days.Friday },
            Weeks = (int)WeekOcurrence.Two
        });
        
        Assert.Equal(expectedResult,result.Item3);
    }
}