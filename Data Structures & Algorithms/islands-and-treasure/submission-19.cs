public class Solution
{
    private readonly List<(int Row, int Col)> _offsets = new()
        { (1, 0), (0, 1), (-1, 0), (0, -1) };
    
    private bool InBounds(int[][] grid, int row, int col)
        => (row >= 0 && row < grid.Length) && (col >= 0 && col < grid[0].Length);

    public void islandsAndTreasure(int[][] grid)
    {
        var queue = new Queue<(int Row, int Col)>();

        for (var row = 0; row < grid.Length; row++)
            for (var col = 0; col < grid[0].Length; col++)
                if (grid[row][col] == 0)
                    queue.Enqueue((row, col));
        
        while (queue.Count > 0)
        {
            var (row, col) = queue.Dequeue();
                
            foreach (var (dr, dc) in _offsets)
            {
                if (!InBounds(grid, row + dr, col + dc)
                    || grid[row + dr][col + dc] != int.MaxValue)
                    continue;

                queue.Enqueue((row + dr, col + dc));
                grid[row + dr][col + dc] = grid[row][col] + 1;
            }
        }
    }
}
