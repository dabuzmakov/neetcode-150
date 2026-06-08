public class Solution {
    public bool IsAnagram(string s, string t) {
        if (s.Length != t.Length)
        {
            return false;
        }
        
        var dict = new Dictionary<char, int>();
        foreach (var sym in s)
        {
            if (dict.TryGetValue(sym, out int count))
                dict[sym] = count + 1;
            else dict[sym] = 1;
        }

        foreach (var sym in t)
        {
            if (!dict.ContainsKey(sym))
                return false;
            
            if (--dict[sym] == 0)
                dict.Remove(sym);
        }
        
        return dict.Count() == 0;
    }
}
