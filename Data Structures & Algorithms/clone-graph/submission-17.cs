public class Solution
{
    private readonly Dictionary<Node, Node> _dict = new();

    public Node CloneGraph(Node node)
    {
        if (node == null) return null;
        if (_dict.TryGetValue(node, out var clone))
            return clone;
        
        clone = new Node(node.val);
        _dict[node] = clone;

        foreach (var child in node.neighbors)
            clone.neighbors.Add(CloneGraph(child));
        
        return clone;
    }
}
