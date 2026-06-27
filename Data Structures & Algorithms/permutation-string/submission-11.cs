public class Solution
{
    public bool CheckInclusion(string s1, string s2)
    {
        if (s1.Length > s2.Length) 
            return false;
            
        var sourceHash = new Dictionary<char, int>();
        var slidingHash = new Dictionary<char, int>();

        for (var i = 0; i < s1.Length; i++)
        {
            sourceHash[s1[i]] = sourceHash.GetValueOrDefault(s1[i]) + 1;
            slidingHash[s2[i]] = slidingHash.GetValueOrDefault(s2[i]) + 1;
        }
        
        var left = 0;
        var right = s1.Length - 1;

        while (right < s2.Length)
        {
            if (AreEqual(sourceHash, slidingHash))
                return true;
            
            if (right == s2.Length - 1) break;

            slidingHash[s2[left++]]--;
            slidingHash[s2[++right]] = slidingHash.GetValueOrDefault(s2[right]) + 1;

            if (slidingHash[s2[left - 1]] == 0) slidingHash.Remove(s2[left - 1]);
        }

        return false;
    }

    private bool AreEqual(Dictionary<char, int> first, Dictionary<char, int> second)
        => first.Count == second.Count 
           && first.All(pair => second.TryGetValue(pair.Key, out var value) && value == pair.Value);
}