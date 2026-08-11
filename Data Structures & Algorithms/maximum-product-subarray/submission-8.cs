public class Solution
{
    public int MaxProduct(int[] nums)
    {
        var (max, min, result) = (nums[0], nums[0], nums[0]);

        for (var i = 1; i < nums.Length; i++)
        {
            var cur = nums[i];
            var newMax = Math.Max(Math.Max(max * cur, min * cur), cur);
            var newMin = Math.Min(Math.Min(max * cur, min * cur), cur);
            (max, min) = (newMax, newMin);
            result = Math.Max(Math.Max(newMax, newMin), result);
        }
        
        return result;
    }
}
