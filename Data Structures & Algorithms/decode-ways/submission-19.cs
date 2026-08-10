public class Solution
{
    public int NumDecodings(string s)
    {
        var (first, second) = (1, 0);

        for (var i = s.Length - 1; i >= 0; i--)
        {
            var current = s[i] != '0'
                ? first + 
                    ((i + 1 < s.Length && (s[i] == '1' || s[i] == '2' && s[i + 1] < '7'))
                    ? second 
                    : 0)
                : 0;

            second = first;
            first = current;
        }

        return first;
    }
}
