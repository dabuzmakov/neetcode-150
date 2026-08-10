public class Solution 
{
    public int CountSubstrings(string s)
        => s.Select(
            (_, i) => CountPalindromes(s, i, i) + CountPalindromes(s, i, i + 1))
            .Sum();

    private int CountPalindromes(string s, int left, int right)
    {
        var count = 0;

        while (left >= 0 && right < s.Length && s[left] == s[right])
            { count++; left--; right++; }

        return count;
    }
}