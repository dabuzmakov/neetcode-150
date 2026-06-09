public class Solution
{
    public int LongestConsecutive(int[] nums) 
    {
        GetBorders(nums, out var min, out var max);

        var hash = new HashSet<int>(nums);
        var maxSequence = 0;
        var curSequence = 0;

        for (var i = min; i <= max; i++)
        {
            if (!hash.Contains(i))
            {
                curSequence = 0;
                continue;
            }

            curSequence++;
            maxSequence = Math.Max(curSequence, maxSequence);
        }

        return maxSequence;
    }

    public void GetBorders(int[] nums, out int min, out int max)
    {
        min = int.MaxValue;
        max = int.MinValue;

        foreach (var num in nums)
        {
            min = num < min ? num : min;
            max = num > max ? num : max;
        }
    }
}
