public class Solution
{
    public int LengthOfLIS(int[] nums)
    {
        var dp = new int[nums.Length];
        dp[0] = 1;

        for (var i = 1; i < nums.Length; i++)
        {
            for (var j = 0; j < i; j++)
                if (nums[j] < nums[i])
                    dp[i] = Math.Max(dp[i], dp[j]);
            dp[i]++;
        }

        return dp.Max();
    }
}
