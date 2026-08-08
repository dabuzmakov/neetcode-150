public class Solution
{
    private readonly (int Row, int Col)[] _offsets = new[]
        { (1, 0), (0, 1), (-1, 0), (0, -1) };
    
    private bool InBounds(int[][] heights, int row, int col)
        => (row >= 0 && row < heights.Length) && (col >= 0 && col < heights[0].Length);

    public List<List<int>> PacificAtlantic(int[][] heights)
    {
        var pacificSet = new bool[heights.Length, heights[0].Length];
        var atlanticSet = new bool[heights.Length, heights[0].Length];
        var pacificQueue = new Queue<(int Row, int Col)>();
        var atlanticQueue = new Queue<(int Row, int Col)>();
        var result = new List<List<int>>();

        for (var row = 0; row < heights.Length; row++)
        for (var col = 0; col < heights[0].Length; col++)
        {
            if (col == 0 || row == 0) 
                pacificQueue.Enqueue((row, col));
            if (col == heights[0].Length - 1 || row == heights.Length - 1)
                atlanticQueue.Enqueue((row, col));
        }

        FindOcean(heights, pacificQueue, pacificSet);
        FindOcean(heights, atlanticQueue, atlanticSet);

        for (var row = 0; row < heights.Length; row++)
        for (var col = 0; col < heights[0].Length; col++)
            if (pacificSet[row, col] && atlanticSet[row, col])
                result.Add(new List<int>() { row, col });
        
        return result;
    }

    private void FindOcean(int[][] heights, Queue<(int, int)> queue, bool[,] oceanSet)
    {
        while (queue.Count > 0)
        {
            var (row, col) = queue.Dequeue();
            oceanSet[row, col] = true;

            foreach (var (dr, dc) in _offsets)
                if (InBounds(heights, row + dr, col + dc)
                    && heights[row + dr][col + dc] >= heights[row][col]
                    && oceanSet[row + dr, col + dc] == false)
                    queue.Enqueue((row + dr, col + dc));
        }
    }
}
