public class Solution
{
    public bool CanAttendMeetings(List<Interval> intervals)
    {
        intervals.Sort((i1, i2) => i1.start.CompareTo(i2.start));

        for (var i = 0; i < intervals.Count - 1; i++)
            if (intervals[i].end > intervals[i + 1].start)
                return false;

        return true;
    }
}
