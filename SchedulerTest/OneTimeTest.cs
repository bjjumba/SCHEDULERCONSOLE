using SchedulerClassLib;

namespace SchedulerTest;

public class OneTimeTest
{
   [Fact]
   public void OnceOccurence()
   {
      var expectedDate = new DateTime(2024, 5, 12, 23, 30, 45);
      var result = Computation.ComputeNextDate(new Config
      {
         ConfDateTime = new DateTime(2024, 5, 12, 23, 30, 45)
      });
      
      Assert.Equal(expectedDate,result.Item1);
   }
}