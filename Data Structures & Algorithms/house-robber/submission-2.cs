public class Solution
{
    public int Rob(int[] nums)
    {
        if (nums.Length == 1) return nums[0];
        var dpTable = new int[nums.Length];
        dpTable[0] = nums[0];
        dpTable[1] = Math.Max(nums[0], nums[1]);

        for (var i = 2; i < nums.Length; i++)
            dpTable[i] = Math.Max(dpTable[i - 2] + nums[i], dpTable[i - 1]);
        
        return dpTable[nums.Length - 1];
    }
}
