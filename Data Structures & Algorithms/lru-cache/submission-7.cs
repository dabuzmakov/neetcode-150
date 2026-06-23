public class LRUCache
{
    private readonly Dictionary<int, Node> _cache;
    private readonly Node _left;
    private readonly Node _right;
    private int _capacity;

    public LRUCache(int capacity)
    {
        _cache = new Dictionary<int, Node>();
        _left = new Node(0, 0);
        _right = new Node(0, 0);
        _capacity = capacity;
    }
    
    public int Get(int key)
    {
        if (!_cache.TryGetValue(key, out var node))
            return -1;
        
        Remove(node);
        Push(node);

        return node.Value;
    }
    
    public void Put(int key, int value)
    {
        if (_cache.TryGetValue(key, out var node))
        {
            node.Value = value;
            Remove(node);
            Push(node);
            return;
        }

        var newNode = new Node(key, value);
        _cache[key] = newNode;
        Push(newNode);

        if (_cache.Count > _capacity)
        {
            var lru = _left.Next;
            Remove(lru);
            _cache.Remove(lru.Key);
        }
    }

    public void Remove(Node node)
    {
        var leftNode = node.Prev ?? _left;
        var rightNode = node.Next ?? _right;

        leftNode.Next = rightNode;
        rightNode.Prev = leftNode;
    }

    public void Push(Node node)
    {
        var leftNode = _right.Prev ?? _left;

        leftNode.Next = node;
        node.Prev = leftNode;

        node.Next = _right;
        _right.Prev = node;
    }
}

public class Node
{
    public int Key { get; set; }
    public int Value { get; set; }
    public Node Next { get; set; }
    public Node Prev { get; set; }

    public Node(int key, int value, Node prev = null, Node next = null)
    {
        Key = key;
        Value = value;
        Next = next;
        Prev = prev;
    }
}
