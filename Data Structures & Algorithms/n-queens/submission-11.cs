public class Solution
{
    private readonly List<List<string>> _result = new();

    public List<List<string>> SolveNQueens(int n)
    {
        var current = new char[n, n];

        for (var i = 0; i < n; i++)
        for (var j = 0; j < n; j++)
            current[i, j] = '.';

        FindAll(current, 0, new HashSet<int>(), 
            new HashSet<int>(), new HashSet<int>());
        
        return _result;
    }

    private void FindAll(
        char[,] current, 
        int row,
        HashSet<int> columns,
        HashSet<int> diagonals1,
        HashSet<int> diagonals2)
    {
        if (row == current.GetLength(0))
        {
            var result = Enumerable.Range(0, current.GetLength(0))
                .Select(row => new string(
                    Enumerable.Range(0, current.GetLength(1))
                        .Select(col => current[row, col])
                    .ToArray()))
                .ToList();
            
            _result.Add(result);
            return;
        }

        for (var column = 0; column < current.GetLength(0); column++)
        {
            if (columns.Contains(column) || 
                diagonals1.Contains(row - column) || 
                diagonals2.Contains(row + column))
            {
                continue;
            }

            current[row, column] = 'Q';
            columns.Add(column);
            diagonals1.Add(row - column);
            diagonals2.Add(row + column);

            FindAll(current, row + 1, columns, diagonals1, diagonals2);

            current[row, column] = '.';
            columns.Remove(column);
            diagonals1.Remove(row - column);
            diagonals2.Remove(row + column);
        }

        return;
    }
}
