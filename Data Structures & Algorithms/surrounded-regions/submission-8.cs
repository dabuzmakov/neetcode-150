public class Solution
{
    private readonly HashSet<(int Row, int Col)> _independent = new();

    private readonly (int Row, int Col)[] _offsets = new[] 
        { (1, 0), (0, 1), (-1, 0), (0, -1) };
    
    private bool InBounds(char[][] board, int row, int col)
        => (row >= 0 && row < board.Length) && (col >= 0 && col < board[0].Length);

    public void Solve(char[][] board)
    {
        for (var row = 0; row < board.Length; row++)
        for (var col = 0; col < board[0].Length; col++)
        {
            if (row != 0 && row != board.Length - 1 
                && col != 0 && col != board[0].Length - 1
                || _independent.Contains((row, col))
                || board[row][col] == 'X')
                continue;

            _independent.Add((row, col));
        }

        BFS(board, new Queue<(int, int)>(_independent));
        
        for (var row = 0; row < board.Length; row++)
        for (var col = 0; col < board[0].Length; col++)
            if (board[row][col] == 'O' && !_independent.Contains((row, col)))
                board[row][col] = 'X';
    }

    private void BFS(char[][] board, Queue<(int, int)> queue)
    {
        while (queue.Count > 0)
        {
            var (row, col) = queue.Dequeue();
            
            foreach (var (dr, dc) in _offsets)
                if (InBounds(board, row + dr, col + dc)
                    && board[row + dr][col + dc] == 'O'
                    && _independent.Add((row + dr, col + dc)))
                    queue.Enqueue((row + dr, col + dc));
        }
    }
}