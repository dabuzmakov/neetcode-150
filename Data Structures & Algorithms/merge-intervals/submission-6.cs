public class Solution
{
    public int[][] Merge(int[][] intervals)
    {
        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));
        var result = new List<int[]>();
        var toAdd = new int[2];
        var i = 0;

        while (i < intervals.Length)
        {
            toAdd = intervals[i];

            while (i < intervals.Length - 1 && toAdd[1] >= intervals[i + 1][0])
            {
                toAdd[1] = Math.Max(toAdd[1], intervals[i + 1][1]);
                i++;
            }

            result.Add(new int[2] { toAdd[0], toAdd[1] });
            i++;
        }

        return result.ToArray();
    }
}
