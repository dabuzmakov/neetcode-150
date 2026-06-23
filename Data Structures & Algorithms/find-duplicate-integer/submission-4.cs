public class Solution
{
    public int FindDuplicate(int[] nums)
    {
        for (var i = 0; i < nums.Length; i++)
        {
            var abs = Math.Abs(nums[i]);
            if (nums[abs] < 0)  return abs; 
            nums[abs] *= -1;
        }

        return 0;
    }
}
