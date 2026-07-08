public class PrefixTree
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

    public PrefixTree() => Root = new TrieNode();
    
    public void Insert(string word)
    {
        TrieNode current = Root;

        for (var i = 0; i < word.Length; i++)
        {
            if (current.Children.TryGetValue(word[i], out var node))
            {
                current = node;
                
                if (i == word.Length - 1) 
                    node.IsKey = true;

                continue;
            }

            var newNode = new TrieNode(i == word.Length - 1);
            current.Children[word[i]] = newNode;
            current = newNode;
        }
    }
    
    public bool Search(string word)
    {
        TrieNode current = Root;

        for (var i = 0; i < word.Length; i++)
        {
            if (!current.Children.TryGetValue(word[i], out var node))
                return false;
            
            current = node;
        }

        return current.IsKey == true;
    }
    
    public bool StartsWith(string prefix)
    {
        TrieNode current = Root;

        for (var i = 0; i < prefix.Length; i++)
        {
            if (!current.Children.TryGetValue(prefix[i], out var node))
                return false;
            
            current = node;
        }

        return true;
    }
}
