public class Solution
{
    public int EvalRPN(string[] tokens)
    {
        var stack = new Stack<int>();
        var operations = new HashSet<string> { "+", "-", "*", "/" };

        foreach (var token in tokens)
        {
            if (!operations.Contains(token))
                stack.Push(int.Parse(token));
            else
            {
                var right = stack.Pop();
                var left = stack.Pop();
                var result = token switch 
                {
                    "+" => left + right,
                    "-" => left - right,
                    "*" => left * right,
                    "/" => left / right
                };

                stack.Push(result);
            }
        }

        return stack.Peek();
    }
}
