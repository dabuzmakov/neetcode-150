public class Solution
{
    public string MinWindow(string s, string t)
    {
        if (s.Length < t.Length || t == string.Empty) 
            return string.Empty;

        var source = new Dictionary<char, int>();
        var current = new Dictionary<char, int>();
        var result = (0, int.MaxValue);
        var left = 0;
        var matches = 0;
        
        foreach (var symbol in t)
            source[symbol] = source.GetValueOrDefault(symbol) + 1;
        
        for (var right = 0; right < s.Length; right++)
        {
            var rightSymbol = s[right];

            if (source.ContainsKey(rightSymbol))
            {
                current[rightSymbol] = current.GetValueOrDefault(rightSymbol) + 1;
                if (current[rightSymbol] == source[rightSymbol])
                    matches++;
            }

            while (matches == source.Count)
            {
                if (right - left < result.Item2 - result.Item1)
                    result = (left, right);

                if (current.ContainsKey(s[left])) 
                {
                    if (current[s[left]] == source[s[left]])
                        matches--;
                    
                    current[s[left]]--;
                }
                left++;
            }            
        }

        return result.Item2 - result.Item1 == int.MaxValue 
            ? string.Empty 
            : s[result.Item1..(result.Item2 + 1)];
    }
}
