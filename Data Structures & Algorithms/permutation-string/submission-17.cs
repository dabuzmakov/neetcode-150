public class Solution
{
    public bool CheckInclusion(string s1, string s2)
    {
        if (s1.Length > s2.Length) return false;
            
        var sourceHash = new int[26];
        var slidingHash = new int[26];
        var matches = 0;

        for (var i = 0; i < s1.Length; i++)
        {
            sourceHash[s1[i] - 'a']++;
            slidingHash[s2[i] - 'a']++;
        }
        
        for (var i = 0; i < sourceHash.Length; i++)
            matches += sourceHash[i] == slidingHash[i] ? 1 : 0;

        for (var right = s1.Length; right < s2.Length; right++)
        {
            if (matches == 26) return true;

            var rightIndex = s2[right] - 'a';
            var leftIndex = s2[right - s1.Length] - 'a';

            slidingHash[rightIndex]++; 
            if (sourceHash[rightIndex] == slidingHash[rightIndex]) matches++;
            else if (slidingHash[rightIndex] - sourceHash[rightIndex] == 1) matches--;

            slidingHash[leftIndex]--;
            if (sourceHash[leftIndex] == slidingHash[leftIndex]) matches++;
            else if (sourceHash[leftIndex] - slidingHash[leftIndex] == 1) matches--;
        }

        return matches == 26;
    }
}