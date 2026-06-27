public class Solution
{
    public int CharacterReplacement(string s, int k)
    {
        var freqDict = new Dictionary<char, int>();
        var maxLength = 0;
        var left = 0;

        for (var right = 0; right < s.Length; right++)
        {
            freqDict[s[right]] = freqDict.GetValueOrDefault(s[right]) + 1;

            var maxFreq = freqDict.MaxBy(pair => pair.Value).Value; 

            while (right - left + 1 - maxFreq > k)
            {
                freqDict[s[left++]]--;
                maxFreq = freqDict.MaxBy(pair => pair.Value).Value;
            }

            maxLength = Math.Max(maxLength, right - left + 1);
        }

        return maxLength;
    }
}
