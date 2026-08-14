public class Solution
{
    public int[] MinInterval(int[][] intervals, int[] queries)
    {
        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

        var sortedQueries = queries
            .Select((query, index) => (query, index))
            .OrderBy(x => x.query);

        var queue = new PriorityQueue<int[], int>();
        var result = new int[queries.Length];
        var j = 0;

        foreach (var (query, index) in sortedQueries)
        {
            while (j < intervals.Length && intervals[j][0] <= query)
            {
                var length = intervals[j][1] - intervals[j][0] + 1;
                queue.Enqueue(intervals[j++], length);
            }
            
            while (queue.Count != 0 && queue.Peek()[1] < query)
                queue.Dequeue();
            
            result[index] = queue.Count == 0 
                ? -1 : queue.Peek()[1] - queue.Peek()[0] + 1;
        }

        return result;
    }
}
