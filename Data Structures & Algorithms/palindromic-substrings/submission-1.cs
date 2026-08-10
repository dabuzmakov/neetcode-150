public class Solution 
{
    public int CountSubstrings(string s)
    {
        var count = 0;

        for (var i = 0; i < s.Length; i++)
            count+= (GetMaxPalindrome(s, i, false) / 2 + 1
                + GetMaxPalindrome(s, i, true) / 2);

        return count;
    }

    private int GetMaxPalindrome(string s, int index, bool isEven)
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
}
