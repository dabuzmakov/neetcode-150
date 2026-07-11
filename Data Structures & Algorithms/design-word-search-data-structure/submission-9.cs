public class WordDictionary
{
    public class TrieNode
    {
        public bool IsKey { get; set; }
        public Dictionary<char, TrieNode> Children { get; set; }

        public TrieNode(bool isKey = false)
        {
            IsKey = isKey;
            Children = new Dictionary<char, TrieNode>();
        }
    }

    public TrieNode Root { get; set; }

    public WordDictionary()
        => Root = new TrieNode();
    
    public void AddWord(string word)
    {
        var current = Root;

        for (var i = 0; i < word.Length; i++)
        {
            if (current.Children.TryGetValue(word[i], out var node))
            {
                current = node;

                if (word.Length - 1 == i)
                    current.IsKey = true;

                continue;
            }

            var newNode = new TrieNode(word.Length - 1 == i);
            current.Children[word[i]] = newNode;
            current = newNode;
        }
    }
    
    public bool Search(string word)
        => Search(Root, word, 0);

    private bool Search(TrieNode curNode, string word, int index)
    {
        var current = curNode;

        while (index < word.Length)
        {
            if (!current.Children.TryGetValue(word[index], out var node))
            {
                if (word[index++] == '.')
                    foreach (var child in current.Children.Values)
                        if (Search(child, word, index))
                            return true;

                return false;
            }
            
            current = node;
            index++;
        }

        return current.IsKey;
    }
}
