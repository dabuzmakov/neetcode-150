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
}