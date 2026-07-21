public class Solution
{
    public int FindKthLargest(int[] nums, int k)
    {
        var queue = new PriorityQueue<int, int>();

        foreach (var num in nums)
        {
            queue.Enqueue(num, num);
            if (queue.Count > k) 
                queue.Dequeue();
        }

        while (queue.Count > k) 
            queue.Dequeue();
        
        return queue.Peek();
    }
}
