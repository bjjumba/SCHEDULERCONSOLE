namespace SchedulerClassLib;
public class Config
{
    public DateTime ConfDateTime { get; set; } //only happens in once scenario
    public DateTime CurrentDate { get; set; } //input in all scenarios
    public Occurence OccurenceType { get; set; } //input in all scenarios
    public int OccursEvery { get; set; } // input needed only in recurring
    public int EveryHours { get; set; } // input needed only in recurring
    public DateTime StartDate { get; set; } //input required for both
    public DateTime EndDate { get; set; } //input required for both
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
}