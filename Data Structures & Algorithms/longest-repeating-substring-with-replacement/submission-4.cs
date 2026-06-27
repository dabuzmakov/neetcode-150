public class Solution
{
    public int CharacterReplacement(string s, int k)
    {
        var freqDict = new Dictionary<char, int>();
        var maxFreq = 0;
        var maxLength = 0;
        var left = 0;

        for (var right = 0; right < s.Length; right++)
        {
            var symbol = s[right];
            freqDict[symbol] = freqDict.GetValueOrDefault(symbol) + 1;
            maxFreq = Math.Max(maxFreq, freqDict[symbol]);

            while (right - left + 1 - maxFreq > k)
                freqDict[s[left++]]--;

            maxLength = Math.Max(maxLength, right - left + 1);
        }

        return maxLength;
    }
}
