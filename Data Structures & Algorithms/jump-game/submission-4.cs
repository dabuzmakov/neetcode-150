public class Solution
{
    public bool CanJump(int[] nums)
    {
        var goal = nums.Length - 1;
        
        for (var i = nums.Length - 2; i >= 0; i--)
            if (nums[i] + i >= goal) 
                goal = i;
        
        return goal == 0;
    }
}
