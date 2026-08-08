public class Solution
{
    private readonly List<(int Row, int Col)> _offsets = new()
        { (1, 0), (0, 1), (-1, 0), (0, -1) };
    
    private bool InBounds(int[][] grid, int row, int col)
        => (row >= 0 && row < grid.Length) && (col >= 0 && col < grid[0].Length);

    public int OrangesRotting(int[][] grid)
    {
        var queue = new Queue<(int Row, int Col)>();
        var freshCount = 0;

        for (var row = 0; row < grid.Length; row++)
        for (var col = 0; col < grid[0].Length; col++)
        {
            if (grid[row][col] == 1)
                freshCount++;
            else if (grid[row][col] == 2)
                queue.Enqueue((row, col));
        }

        if (queue.Count == 0) 
            return freshCount == 0 ? 0 : -1;

        var minutes = 0;
        while (queue.Count > 0)
        {
            var levelCount = queue.Count;

            for (var i = 0; i < levelCount; i++)
            {
                var (row, col) = queue.Dequeue();

                foreach (var (dr, dc) in _offsets)
                {
                    if (!InBounds(grid, row + dr, col + dc))
                        continue;
                    
                    if (grid[row + dr][col + dc] != 1)
                        continue;

                    queue.Enqueue((row + dr, col + dc));
                    grid[row + dr][col + dc] = 2;
                    freshCount--;
                }
            }

            minutes++;
        }

        return freshCount == 0 ? minutes - 1 : -1;
    }
}
