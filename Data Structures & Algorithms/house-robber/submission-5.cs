public class Solution
{
    public int Rob(int[] nums)
    {
        var (rob1, rob2) = (0, 0);

        foreach (var num in nums)
        {
            var current = Math.Max(rob1 + num, rob2);
            (rob1, rob2) = (rob2, current);
        }
        
        return rob2;
    }
}
