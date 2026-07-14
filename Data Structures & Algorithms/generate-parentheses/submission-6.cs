public class Solution
{  
    private List<string> _result = new();

    public List<string> GenerateParenthesis(int n)
    {
        FindAll(new StringBuilder("("), 2 * n, 1, 0);
        return _result;
    }

    private void FindAll(StringBuilder current, int needLength, int open, int close)
    {
        if (close > open || current.Length > needLength) 
            return;

        if (current.Length == needLength && open == close)
        {
            _result.Add(current.ToString());
            return;
        }
        
        current.Append("(");
        FindAll(current, needLength, open + 1, close);
        current.Length--;

        current.Append(")");
        FindAll(current, needLength, open, close + 1);
        current.Length--;
    }
}
