public class Solution
{
    private int _result = 0;

    public int CountComponents(int n, int[][] edges) 
    {
        var graph = new List<int>[2*n];
        var visited = new bool[n];

        for (var i = 0; i < n; i++)
            graph[i] = new List<int>();
        
        foreach (var edge in edges)
        {
            graph[edge[0]].Add(edge[1]);
            graph[edge[1]].Add(edge[0]);
        }

        for (var i = 0; i < n; i++)
        {
            if (visited[i]) continue;
            DFS(graph, visited, i, -1);
            _result++;
        }
        
        return _result;
    }

    private void DFS(List<int>[] graph, bool[] visited, int node, int prev)
    {
        if (visited[node]) return;
        visited[node] = true;

        foreach (var next in graph[node])
        {
            if (next == prev) continue;
            DFS(graph, visited, next, node);
        }
    }
}




