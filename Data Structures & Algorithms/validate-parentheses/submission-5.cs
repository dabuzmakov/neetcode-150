public class Solution 
{
    public bool IsValid(string s) 
    {
        var stack = new Stack<char>();
        var bracketsDict = new Dictionary<char, char>() 
        { 
            ['('] = ')', 
            ['{'] = '}',
            ['['] = ']',
        };

        foreach (var bracket in s)
        {
            if (bracketsDict.ContainsKey(bracket))
                stack.Push(bracket);
            else
            {
                if (stack.Count == 0 || bracket != bracketsDict[stack.Peek()])
                    return false;
                stack.Pop();
            }
        }

        return stack.Count == 0;
    }
}
