public class Solution
{
    private readonly (int, int)[] _offset =
    {
        (-1, 0), (1, 0),
        (0, -1), (0, 1), 
    };

    private char[][] _board;
    private string[] _words;
    private List<string> _result;
    private bool[,] _checked;

    public List<string> FindWords(char[][] board, string[] words)
    {
        (_board, _words, _result, _checked) 
            = (board, words, new(), new bool[board.Length, board[0].Length]);

        var trie = new PrefixTree();
        for (var i = 0; i < words.Length; i++)
            trie.Add(words[i], i);

        for (var i = 0; i < board.Length; i++)
        for (var j = 0; j < board[0].Length; j++)
            Search(i, j, trie.Root);
        
        return _result;
    }

    public void Search(int i, int j, TrieNode curNode)
    {
        if (_checked[i, j] || !curNode.Children.TryGetValue(_board[i][j], out var newNode))
            return;
            
        _checked[i, j] = true;

        if (newNode.Index != -1)
        {
            _result.Add(_words[newNode.Index]);
            newNode.Index = -1;
        }

        foreach (var (dx, dy) in _offset)
            if (InBounds(i + dx, j + dy))
                Search(i + dx, j + dy, newNode);

        _checked[i, j] = false;
    }

    public bool InBounds(int x, int y)
        => (x >= 0) && (x < _board.Length)
        && (y >= 0) && (y < _board[0].Length);

    public class PrefixTree
    {
        public TrieNode Root { get; private set; } = new();
        
        public void Add(string word, int index)
        {
            var current = Root;

            for (var i = 0; i < word.Length; i++)
            {
                if (!current.Children.TryGetValue(word[i], out var node))
                {
                    node = new TrieNode();
                    current.Children[word[i]] = node;
                }

                current = node;
            }

            current.Index = index;
        }
    }

    public class TrieNode
    {
        public Dictionary<char, TrieNode> Children { get; } = new();
        public int Index { get; set; } = -1;
    }
}
