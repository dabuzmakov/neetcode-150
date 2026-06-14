public class Solution
{
    public int MaxArea(int[] heights)
    {
        var left = 0;
        var right = heights.Length - 1;
        var maxArea = 0;

        while (left < right)
        {
            var height = Math.Min(heights[left], heights[right]);
            var length = right - left;
            maxArea = Math.Max(maxArea, height * length);

            if (heights[right] >= heights[left]) left++;
            else right--;
        }

        return maxArea;
    }
}
