public class Solution
{
    private readonly List<(int R, int C)> _offsets = new()
        { (1, 0), (0, 1), (-1, 0), (0, -1) };

    public int MaxAreaOfIsland(int[][] grid)
    {
        var result = 0;

        for (var row = 0; row < grid.Length; row++)
        for (var col = 0; col < grid[0].Length; col++)
            if (grid[row][col] == 1)
                result = Math.Max(result, GetArea(grid, row, col));

        return result;
    }

    private bool InBounds(int[][] grid, int row, int col)
        => (row >= 0 && row < grid.Length) && (col >= 0 && col < grid[0].Length);

    private int GetArea(int[][] grid, int row, int col)
    {
        grid[row][col] = 0;
        var area = 1;
    
        foreach (var offset in _offsets)
            if (InBounds(grid, row + offset.R, col + offset.C) 
                && grid[row + offset.R][col + offset.C] == 1)
                area += GetArea(grid, row + offset.R, col + offset.C);
        
        return area;
    }
}
