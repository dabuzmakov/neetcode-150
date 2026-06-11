public class Solution
{
    public int[] DailyTemperatures(int[] temperatures)
    {
        var stack = new Stack<int>();
        var result = new int[temperatures.Length];

        for (var i = 0; i < temperatures.Length; i++)
        {
            while (stack.Count != 0 && temperatures[i] > temperatures[stack.Peek()])
            {
                var index = stack.Peek();
                result[index] = i - index;
                stack.Pop();
            }

            stack.Push(i);
        }   
        
        return result;
    }
}
