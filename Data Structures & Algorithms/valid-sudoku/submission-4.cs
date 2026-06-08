public class Solution 
{
    public bool IsValidSudoku(char[][] board) 
    {
        var rows = new Dictionary<int, HashSet<char>>();
        var columns = new Dictionary<int, HashSet<char>>();
        var sectors = new Dictionary<(int, int), HashSet<char>>();

        for (var i = 0; i < 9; i++)
        {
            rows[i] = new HashSet<char>();
            columns[i] = new HashSet<char>();
            if (i < 3)
                for (var j = 0; j < 3; j++)
                    sectors[(i, j)] = new HashSet<char>();
        }

        for (var i = 0; i < board.Length; i++)
        for (var j = 0; j < board.Length; j++)
        {
            var cell = board[i][j];
            var sector = (i / 3, j / 3);
            if (cell != '.' && (!rows[i].Add(cell) ||
                !columns[j].Add(cell) || !sectors[sector].Add(cell)))
                return false;
        }

        return true;
    }
}
