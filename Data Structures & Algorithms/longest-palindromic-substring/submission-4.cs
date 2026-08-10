public class Solution
{
    public string LongestPalindrome(string s)
    {
        var longest = -1;
        var maxLength = 0;

        for (var i = 0; i < s.Length; i++)
        {
            var length = Math.Max(GetPalindrome(s, i, false), GetPalindrome(s, i, true));

            if (length > maxLength)
                (maxLength, longest) = (length, i);
        }

        return Build(s, longest, maxLength);
    }

    private int GetPalindromeOdd(string s, int index)
    {
        var offset = 0;
        while (true)
        {
            if (index + offset < s.Length 
                && index - offset >= 0
                && s[index + offset] == s[index - offset])
                offset++;
            else break;
        }

        return (offset - 1) * 2 + 1;
    }

    private int GetPalindromeEven(string s, int index)
    {
        if (index - 1 < 0 || s[index - 1] != s[index]) 
            return 0;
        
        var offset = 0;
        while (true)
        {
            if (index + offset < s.Length
                && index - 1 - offset >= 0
                && s[index + offset] == s[index - 1 - offset])
                offset++;
            else break;
        }

        return (offset - 1) * 2 + 2;
    }

    private int GetPalindrome(string s, int index, bool isEven)
    {
        if (isEven && (index - 1 < 0 || s[index - 1] != s[index]))
            return 0;
        
        var modifier = isEven ? 1 : 0;
        var offset = 0;
        while (true)
        {
            if (index + offset < s.Length
                && index - modifier - offset >= 0
                && s[index + offset] == s[index - modifier - offset])
                offset++;
            else break;
        }

        return (offset - 1) * 2 + 1 + modifier;
    }

    private string Build(string s, int index, int length)
    {
        var builder = new StringBuilder();

        for (var i = index - length / 2; i < index + length / 2 + length % 2; i++)
            builder.Append(s[i]);
        
        return builder.ToString();
    }
}
