public class Solution 
{
    public string Encode(IList<string> strs) 
    {
        var sb = new StringBuilder();
        foreach (var word in strs)
            sb.Append($"{word.Length}#{word}");
        return sb.ToString();
    }

    public List<string> Decode(string s) 
    {
        var result = new List<string>();
        var sb = new StringBuilder();
        var position = 0;
        var currentLength = 0;

        while (position < s.Length)
        {
            currentLength = ParseWordLength(s, position, out var newPosition);
            position = newPosition;

            for (var i = 0; i < currentLength; i++)
                sb.Append(s[position++]);
            
            result.Add(sb.ToString());
            sb.Clear();
        }

        return result;
    }

    public static int ParseWordLength(string s, int position, out int newPosition)
    {
        newPosition = position;
        var slength = string.Empty;

        while (s[newPosition] != '#')
            slength += s[newPosition++];
        
        newPosition++;
        return int.Parse(slength);
    }
}
