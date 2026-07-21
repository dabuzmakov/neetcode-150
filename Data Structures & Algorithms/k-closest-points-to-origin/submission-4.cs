public class Solution
{
    public int[][] KClosest(int[][] points, int k)
    {
        var queue = new PriorityQueue<int[], int>();

        foreach (var point in points)
        {
            var (x, y) = (point[0], point[1]);
            queue.Enqueue(new int[2] { x, y }, - x * x - y * y);
            if (queue.Count > k) queue.Dequeue();
        }

        return queue.UnorderedItems.Select(x => x.Element).ToArray();
    }
}
