public class Solution {

    public string Encode(IList<string> strs)
    {
        var sb = new StringBuilder();

        foreach (var str in strs)
        {
            sb.Append(str.Length);
            sb.Append('#');
            sb.Append(str);
        }

        return sb.ToString();
    }

    public List<string> Decode(string s)
    {
        var result = new List<string>();
        int i = 0;

        while (i < s.Length)
        {
            int j = i;

            while (s[j] != '#')
                j++;

            int length = int.Parse(s.Substring(i, j - i));
            j++;

            result.Add(s.Substring(j, length));
            i = j + length;
        }

        return result;
    }
}
