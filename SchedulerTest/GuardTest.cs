using SchedulerClassLib;

namespace SchedulerTest;

public class GuardTest
{
    [Fact]
    public void EndDate_Is_Before_CurrentDate()
    {
        Assert.Throws<Exception>(()=>Computation.ComputeNextDate(new Config
        {
            ConfDateTime = new DateTime(2024, 5, 4, 3, 40, 5),
            CurrentDate = new DateTime(2020, 1, 9),
            OccurenceType = Occurence.Recurring,
            OccursEvery = 1,
            StartDate = new DateTime(2020, 1, 1),
            EndDate = new DateTime(2020, 1, 8)
        }));
    }

    [Fact]
    public void ConfDateTime_Is_In_The_Past()
    {
        //Arrange
        var expectedErrorMessage = "Date and Time must be in the future";

        //Act
        var exception = Assert.Throws<Exception>(() => Computation.ComputeNextDate(new Config
        {
            ConfDateTime = new DateTime(2024, 5, 10, 5, 50, 5)
        }));
        
        //Assert
        Assert.Equal(expectedErrorMessage, exception.Message);
    }
}