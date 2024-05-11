namespace SchedulerTest;
using SchedulerClassLib;

public class SchedulerTest
{
    private readonly Computation _compute;
    public SchedulerTest()
    {
        _compute = new Computation();
    }
    [Fact]
    public void RecurringDateTest()
    {
        //Arrange
        var expectedDate = new DateOnly(2020, 2, 5);
        
        //Act
        var result = _compute.ComputeNextDate(new Config
        {
            ConfDateTime = new DateTime(2024, 5, 4, 3, 40, 5),
            CurrentDate = new DateOnly(2020, 1, 4),
            OccurenceType = Occurence.Recurring,
            OccursEvery = "monthly",
            Days = 0,
            StartDate = new DateOnly(2020, 1, 1),
            EndDate = new DateOnly(2020, 1, 8),
        });
        
        //Assert
        Assert.Equal(expectedDate, result.Item1);
    }
}