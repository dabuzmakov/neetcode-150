public class Solution
{
    public int[] MaxSlidingWindow(int[] nums, int k)
    {
        var result = new int[nums.Length - k + 1];
        var queue = new PriorityQueue<int, int>();

        for (var i = 0; i < k - 1; i++)
            queue.Enqueue(i, -nums[i]);
        
        var left = 0;

        for (var right = k - 1; right < nums.Length; right++)
        {
            queue.Enqueue(right, -nums[right]);

            while (queue.Peek() < left)
                queue.Dequeue();

            result[left++] = nums[queue.Peek()];
        }

        return result;
    }
}
