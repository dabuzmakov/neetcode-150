public class Solution
{
    public bool CanAttendMeetings(List<Interval> intervals)
    {
        var sorted = intervals.OrderBy(x => x.start).ToArray();

        for (var i = 0; i < sorted.Length - 1; i++)
            if (sorted[i].end > sorted[i + 1].start)
                return false;

        return true;
    }
}
