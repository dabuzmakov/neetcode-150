public class Solution
{
    public int LargestRectangleArea(int[] heights)
    {
        var uniqueHeights = new HashSet<int>(heights);
        var result = 0;

        foreach (var targetHeight in uniqueHeights)
        {
            var maxWidth = 0;
            var width = 0;

            foreach (var height in heights)
            {
                if (targetHeight > height)
                {
                    width = 0; 
                    continue;
                }
                width++;
                maxWidth = Math.Max(width, maxWidth);
            }

            result = Math.Max(result, maxWidth * targetHeight);
        }

        return result;
    }
}
