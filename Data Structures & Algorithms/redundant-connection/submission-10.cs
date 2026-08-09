public class Solution
{
    public int[] FindRedundantConnection(int[][] edges)
    {
        var parent = new int[edges.Length + 1];
        var result = new int[2];

        for (var i = 0; i < edges.Length; i++)
            parent[i] = i;
        
        foreach (var edge in edges)
        {
            if (GetRoot(parent, edge[0]) == GetRoot(parent, edge[1]))
                result = edge;

            Union(parent, edge[0], edge[1]);
        }

        return result;
    }

    private int GetRoot(int[] parent, int node)
        => parent[node] == node ? node : GetRoot(parent, parent[node]);

    private void Union(int[] parent, int node1, int node2)
        => parent[GetRoot(parent, node2)] = GetRoot(parent, node1);
}
