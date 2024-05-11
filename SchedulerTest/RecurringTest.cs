namespace SchedulerTest;
using SchedulerClassLib;

public class RecurringTest
{
    [Fact]
    public void CurrentDate_Is_After_StartDate()
    {
        //Arrange
        var expectedDate = new DateOnly(2020, 1, 5);
        
        //Act
        var result = Computation.ComputeNextDate(new Config
        {
            ConfDateTime = new DateTime(2024, 5, 4, 3, 40, 5),
            CurrentDate = new DateOnly(2020, 1, 4),
            OccurenceType = Occurence.Recurring,
            OccursEvery = 1,
            StartDate = new DateOnly(2020, 1, 1),
            EndDate = new DateOnly(2020, 1, 8),
        });
        
        //Assert
        Assert.Equal(expectedDate, result.Item1);
    }
    [Fact]
    public void CurrentDate_Is_Before_StartDate()
    {
        //Arrange
        var expectedDate = new DateOnly(2020, 1, 4);
            
        //Act
        var result = Computation.ComputeNextDate(new Config
        {
            ConfDateTime = new DateTime(2024, 5, 4, 3, 40, 5),
            CurrentDate = new DateOnly(2020, 1, 1),
            OccurenceType = Occurence.Recurring,
            OccursEvery = 1,
            StartDate = new DateOnly(2020, 1, 4),
            EndDate = new DateOnly(2020, 1, 8),
        });
        
        //Assert
        Assert.Equal(expectedDate, result.Item1);
    }
}