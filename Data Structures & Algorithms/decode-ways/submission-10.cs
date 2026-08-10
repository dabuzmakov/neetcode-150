public class Solution
{
    public int NumDecodings(string s)
    {
        var (first, second) = (0, 0);

        if (s.Length == 1) return s[^1] == '0' ? 0 : 1;
        second = s[^1] == '0' ? 0 : 1;

        if (s.Length == 2) return s[^2] == '0' 
            ? 0 : second + (((s[^2] - '0') * 10 + (s[^1] - '0')) < 27
                ? 1 : 0);

        first = s[^2] == '0' 
            ? 0 : second + (((s[^2] - '0') * 10 + (s[^1] - '0')) < 27
                ? 1 : 0);
        
        for (var i = s.Length - 3; i >= 0; i--)
        {
            var number = (s[i] - '0') * 10 + (s[i + 1] - '0');
            var current = s[i] == '0' ? 0 : first + (number < 27 ? second : 0);
            second = first;
            first = current;
        }

        return first;
    }
}
