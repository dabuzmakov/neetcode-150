public class Solution
{
    public int EraseOverlapIntervals(int[][] intervals)
    {
        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));
        var (prevEnd, count) = (-int.MaxValue, 0);

        for (var i = 0; i < intervals.Length; i++)
        {
            if (intervals[i][0] >= prevEnd)
            {
                prevEnd = intervals[i][1];
                continue;
            }
            
            prevEnd = Math.Min(intervals[i][1], prevEnd);
            count++;
        }

        return count;
    }
}
