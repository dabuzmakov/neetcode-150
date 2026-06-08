public class Solution {
    public List<List<string>> GroupAnagrams(string[] strs) 
    {
        var result = new Dictionary<string, List<string>>();

        foreach (var str in strs)
        {
            var chars = str.ToCharArray();
            Array.Sort(chars);
            var key = new string(chars);

            if (result.ContainsKey(key))
                result[key].Add(str);
            else result[key] = new List<string>() { str };
        }

        return result.Values.ToList();
    }
    
    public bool IsAnagram(string s, string t)
    {
        var dict = new Dictionary<char, int>();
        foreach (var sym in s)
        {
            if (dict.TryGetValue(sym, out var count))
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

        return dict.Count == 0;
    }
}
