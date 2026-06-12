public class Solution
{
    public int LargestRectangleArea(int[] heights)
    {
        var stack = new Stack<int>();
        var result = 0;

        for (var i = 0; i <= heights.Length; i++)
        {
            var currentHeight = i == heights.Length ? 0 : heights[i];

            while (stack.Count != 0 && currentHeight < heights[stack.Peek()])
            {
                var height = heights[stack.Pop()];
                var leftBorder = stack.Count == 0 ? -1 : stack.Peek();
                var width = i - leftBorder - 1;

                result = Math.Max(result, height * width);
            }
            
            stack.Push(i);
        }

        return result;
    }
}
