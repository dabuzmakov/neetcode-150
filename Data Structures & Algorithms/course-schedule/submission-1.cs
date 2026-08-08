public class Solution
{
    public bool CanFinish(int numCourses, int[][] prerequisites)
    {
        var graph = new List<int>[numCourses];
        var visited = new byte[numCourses];

        for (var i = 0; i < numCourses; i++)
            graph[i] = new List<int>();
        
        foreach (var edge in prerequisites)
            graph[edge[1]].Add(edge[0]);

        for (var course = 0; course < numCourses; course++)
            if (FindCycle(graph, visited, course))
                return false;
        
        return true;
    }

    public bool FindCycle(List<int>[] graph, byte[] visited, int course)
    {
        if (visited[course] == 1)
            return true;
        
        if (visited[course] == 2)
            return false;

        visited[course] = 1;

        foreach (var next in graph[course])
            if (FindCycle(graph, visited, next))
                return true;
            
        visited[course] = 2;
        return false;
    }
}
