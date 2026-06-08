public class Solution 
{
    public bool IsValidSudoku(char[][] board) 
        => IsValidLines(board, (i, j) => board[i][j])
        && IsValidLines(board, (i, j) => board[j][i])
        && IsValidSectors(board);

    public bool IsValidLines(char[][] board, Func<int, int, char> getCell)
    {
        var checkSet = new HashSet<char>();

        for (var i = 0; i < board.Length; i++)
        {
            for (var j = 0; j < board.Length; j++)
            {
                var cell = getCell(i, j);

                if (cell != '.' && !checkSet.Add(cell))
                    return false;
            }

             checkSet.Clear();
        }

        return true;
    }

    public bool IsValidSectors(char[][] board)
    {
        var initCells = new[] 
        { 
            (0, 0), (0, 3), (0, 6), 
            (3, 0), (3, 3), (3, 6),
            (6, 0), (6, 3), (6, 6)
        };

        foreach (var cell in initCells)
            if (!IsValidSector(board, cell.Item1, cell.Item2))
                return false;
        
        return true;
    }

    public bool IsValidSector(char[][] board, int x, int y)
    {
        var checkSet = new HashSet<char>();

        for (var i = x; i < x + 3; i++)
        for (var j = y; j < y + 3; j++)
            if (board[j][i] != '.' && !checkSet.Add(board[j][i]))
                return false;

        return true;
    }
}
