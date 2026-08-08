public class Solution
{
    public bool ValidTree(int n, int[][] edges)
    {
        if (edges.Length != n - 1)
            return false;

        var visited = new bool[n];
        var graph = new List<int>[n];

        for (var i = 0; i < n; i++)
            graph[i] = new List<int>();
        
        foreach (var edge in edges)
        {
            graph[edge[0]].Add(edge[1]);
            graph[edge[1]].Add(edge[0]);
        }

        if (FindCycle(graph, visited, 0, -1))
            return false;
        
        return visited.All(x => x);
    }

    private bool FindCycle(List<int>[] graph, bool[] visited, int node, int prev)
    {
        if (visited[node]) return true;
        visited[node] = true;

        foreach (var next in graph[node])
        {
            if (next == prev) continue;
            if (FindCycle(graph, visited, next, node))
                return true;
        }

        return false;
    }
}
