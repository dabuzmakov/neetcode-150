public class Solution
{
    private List<List<string>> _result = new();

    public List<List<string>> Partition(string s)
    {
        FindAll(new List<string>(), s, 0);
        return _result;
    }

    private void FindAll(List<string> current, string s, int start)
    {
        if (start == s.Length)
        {
            _result.Add(new List<string>(current));
            return;
        }

        for (var i = start; i < s.Length; i++)
        {
            var candidate = s[start..(i + 1)];
            if (IsPalindromic(candidate))
            {
                current.Add(candidate);
                FindAll(current, s, i + 1);
                current.RemoveAt(current.Count - 1);
            }
        }
    }

    private bool IsPalindromic(string s)
    {
        var left = 0;
        var right = s.Length - 1;

        while (left < right)
            if (s[left++] != s[right--])
                return false;

        return true;
    }
}
