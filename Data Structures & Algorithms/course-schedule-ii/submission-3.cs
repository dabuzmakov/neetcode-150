public class Solution
{
    public int[] FindOrder(int numCourses, int[][] prerequisites)
    {
        var graph = new List<int>[numCourses];
        var queue = new Queue<int>();
        var indegreeSet = new int[numCourses];
        var result = new List<int>();

        for (var i = 0; i < numCourses; i++)
            graph[i] = new List<int>();
        
        foreach (var edge in prerequisites)
        {
            graph[edge[1]].Add(edge[0]);
            indegreeSet[edge[0]]++;
        }

        for (var i = 0; i < numCourses; i++)
            if (indegreeSet[i] == 0) 
                queue.Enqueue(i);

        while (queue.Count > 0)
        {
            var course = queue.Dequeue();
            result.Add(course);

            foreach (var next in graph[course])
                if (--indegreeSet[next] == 0)
                    queue.Enqueue(next);
        }

        return result.Count == numCourses 
            ? result.ToArray()
            : [];
    }
}
