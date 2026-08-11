public class Solution
{
    private readonly Dictionary<int, bool> _cache = new();

    public bool WordBreak(string s, List<string> wordDict)
        => Search(
            s, 0, new HashSet<string>(wordDict),
            wordDict.Select(x => x.Length).Max()
        );

    private bool Search(string s, int index, HashSet<string> hash, int maxLength)
    {
        if (index == s.Length) return true;
        if (_cache.ContainsKey(index)) return _cache[index];
        var result = false;

        for (var i = index; i < Math.Min(s.Length, index + maxLength); i++)
            if (hash.Contains(s[index..(i + 1)]))
            {
                if (!_cache.ContainsKey(i + 1))
                    _cache[i + 1] = Search(s, i + 1, hash, maxLength);
                
                result = result || _cache[i + 1];
            }

        _cache[index] = result;
        return result;
    }
}
