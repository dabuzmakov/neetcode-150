public class Solution
{
    public string MinWindow(string s, string t)
    {
        if (s.Length < t.Length) 
            return string.Empty;

        var source = new Dictionary<char, int>();
        var current = new Dictionary<char, int>();
        var result = string.Empty;
        var left = 0;
        
        foreach (var symbol in t)
            source[symbol] = source.GetValueOrDefault(symbol) + 1;
        
        for (var right = 0; right < s.Length; right++)
        {
            var rightSymbol = s[right];

            if (!source.ContainsKey(rightSymbol)) continue;
            current[rightSymbol] = current.GetValueOrDefault(rightSymbol) + 1;
            if (source.Count != current.Count) continue;

            while (!current.ContainsKey(s[left]) || current[s[left]] > source[s[left]])
            {
                if (current.ContainsKey(s[left])) 
                    current[s[left]]--;
                left++;
            }

            var maxLength = result.Length == 0 ? int.MaxValue : result.Length;
            if (right - left + 1 < maxLength && IsValid(current, source)) 
                result = s[left..(right + 1)];
        }

        return result;
    }

    private bool IsValid(Dictionary<char, int> curr, Dictionary<char, int> src)
        => curr.Count == src.Count 
           && curr.All(pair => src.TryGetValue(pair.Key, out var value) && value <= pair.Value);
}
