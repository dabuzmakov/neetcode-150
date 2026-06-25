public class Solution 
{
    public int LengthOfLongestSubstring(string s)
    {
        var unique = new HashSet<char>();
        var longest = 0;
        var left = 0;

        for (var right = 0; right < s.Length; right++)
        {
            while (unique.Contains(s[right]))
                unique.Remove(s[left++]);

            longest = Math.Max(longest, right - left + 1);
            unique.Add(s[right]);
        }

        return longest;
    }
}
