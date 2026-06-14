public class Solution
{
    public int Trap(int[] height)
    {
        var prefix = new int[height.Length];
        var suffix = new int[height.Length];
        var total = 0;

        var max = 0;
        for (var i = 0; i < height.Length; i++)
        {
            prefix[i] = max;
            max = Math.Max(max, height[i]);
        }

        max = 0;
        for (var i = height.Length - 1; i >= 0; i--)
        {
            suffix[i] = max;
            max = Math.Max(max, height[i]);
        }

        for (var i = 0; i < height.Length; i++)
        {
            var toAdd = Math.Min(prefix[i], suffix[i]) - height[i];
            total += toAdd < 0 ? 0 : toAdd;
        }
        
        return total;
    }
}
