public class Solution {
    public bool IsAnagram(string s, string t) {
        if (s.Length != t.Length) return false;
        var alph = new int[26];

        foreach (var sym in s)
            alph[sym - 'a']++;

        foreach (var sym in t)
        {
            if (--alph[sym - 'a'] < 0)
                return false;
        }
        
        return true;
    }
}
