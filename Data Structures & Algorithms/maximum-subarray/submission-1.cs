public class Solution
{
    public int MaxSubArray(int[] nums)
    {
        var max = int.MinValue;
        var sum = 0;

        foreach (var num in nums)
        {
            sum = Math.Max(num, sum + num);
            max = Math.Max(max, sum);
        }

        return max;
    }
}
