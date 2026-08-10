public class Solution
{
    public int Rob(int[] nums)
    {
        var (rob1, rob2) = (0, 0);

        foreach (var num in nums)
            (rob1, rob2) = (rob2, Math.Max(rob1 + num, rob2));
        
        return rob2;
    }
}
