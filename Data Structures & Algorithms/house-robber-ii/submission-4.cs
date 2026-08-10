public class Solution
{
    public int Rob(int[] nums)
        => Math.Max(
            Math.Max(
                GetOptimum(nums[0..(nums.Length - 1)]), 
                GetOptimum(nums[1..(nums.Length)])
            ), 
            nums[0]
        );

    private int GetOptimum(int[] nums)
    {
        var (rob1, rob2) = (0, 0);

        for (var i = 0; i < nums.Length; i++)
            (rob1, rob2) = (rob2, Math.Max(rob1 + nums[i], rob2));

        return rob2;
    }
}
