public class Solution
{
    public int LadderLength(string beginWord, string endWord, IList<string> wordList)
    {
        var visited = new HashSet<string>();
        var templates = new Dictionary<string, List<string>>();

        wordList.Add(beginWord);
        foreach (var word in wordList)
        {
            for (var i = 0; i < word.Length; i++)
            {
                var chars = word.ToCharArray();
                chars[i] = '*';
                var template = new string(chars);

                if (!templates.ContainsKey(template))
                    templates[template] = new List<string>();

                templates[template].Add(word);
            }
        }

        var queue = new Queue<string>();
        var layer = 0;
        queue.Enqueue(beginWord);

        while (queue.Count > 0)
        {
            var levelSize = queue.Count;
            layer++;

            for (var j = 0; j < levelSize; j++)
            {
                var word = queue.Dequeue();
                if (word == endWord) return layer;

                for (var i = 0; i < word.Length; i++)
                {
                    var chars = word.ToCharArray();
                    chars[i] = '*';
                    var template = new string(chars);

                    foreach (var newWord in templates[template])
                    {
                        if (visited.Contains(newWord))
                            continue;

                        visited.Add(newWord);
                        queue.Enqueue(newWord);
                    }   
                }
            }
        }

        return 0;
    }
}
