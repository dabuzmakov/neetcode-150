public class Solution
{
    public int[] DailyTemperatures(int[] temperatures)
    {
        var stack = new Stack<int>();
        var result = new int[temperatures.Length];

        stack.Push(0);
        for (var i = 1; i < temperatures.Length; i++)
        {
            while (stack.Count != 0 && temperatures[i] > temperatures[stack.Peek()])
            {
                var index = stack.Peek();
                result[index] = i - index;
                stack.Pop();
            }

            stack.Push(i);
        }   

        while (stack.Count != 0)
            result[stack.Pop()] = 0;
        
        return result;
    }
}
