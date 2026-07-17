public class Solution
{
    private readonly List<string> _result = new();
    private readonly Dictionary<char, string> _dict = new()
    {
        ['2'] = "abc",
        ['3'] = "def",
        ['4'] = "ghi",
        ['5'] = "jkl",
        ['6'] = "mno",
        ['7'] = "pqrs",
        ['8'] = "tuv",
        ['9'] = "wxyz",
    };

    public List<string> LetterCombinations(string digits) 
    {
        if (digits == string.Empty) return [];
        FindAll(digits, new StringBuilder(), 0);
        return _result;
    }

    private void FindAll(string digits, StringBuilder current, int index)
    {
        if (index == digits.Length)
        {
            _result.Add(current.ToString());
            return;
        }

        foreach (var sym in _dict[digits[index]])
        {
            current.Append(sym);
            FindAll(digits, current, index + 1);
            current.Length--;
        }
    }
}
