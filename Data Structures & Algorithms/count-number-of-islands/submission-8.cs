public class Solution
{
    private readonly List<(int, int)> _offsets = new()
    {
        (1, 0), (0, 1), (-1, 0), (0, -1)
    };

    private bool InBounds(char[][] grid, int row, int col)
        => (row >= 0 && row < grid.Length) && (col >= 0 && col < grid[0].Length);

    public int NumIslands(char[][] grid)
    {
        var count = 0;

        for (var i = 0; i < grid.Length; i++)
            for (var j = 0; j < grid[0].Length; j++)
                if (grid[i][j] == '1')
                {
                    count++;
                    MarkIsland(grid, i, j);
                }
        
        return count;
    }

    private void MarkIsland(char[][] grid, int row, int col)
    {
        grid[row][col] = 'x';
        foreach (var offset in _offsets)
            if (InBounds(grid, row + offset.Item1, col + offset.Item2) 
                && (grid[row + offset.Item1][col + offset.Item2] == '1'))
                MarkIsland(grid, row + offset.Item1, col + offset.Item2);
    }
}
