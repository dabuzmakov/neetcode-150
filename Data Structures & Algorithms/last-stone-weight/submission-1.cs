public class Solution
{
    public int LastStoneWeight(int[] stones)
    {
        var queue = new PriorityQueue<int, int>();

        foreach (var stone in stones)
            queue.Enqueue(stone, -stone);
        
        while (queue.Count > 1)
        {
            var first = queue.Dequeue();
            var second = queue.Dequeue();

            if (first < second)
                queue.Enqueue(second - first, first - second);
            if (first > second)
                queue.Enqueue(first - second, second - first);
        }

        return queue.Count == 0 ? 0 : queue.Peek();
    }
}
