public class Solution
{
    private char[][] _board;

    private readonly (int, int)[] _offsets
        = { (-1, 0), (1, 0), (0, -1), (0, 1), };

    public bool Exist(char[][] board, string word)
    {
        _board = board;

        for (var i = 0; i < board.Length; i++)
        for (var j = 0; j < board[0].Length; j++)
            if (FindWord(word, 0, i, j)) 
                return true;

        return false;
    }

    private bool FindWord(string word, int index, int i, int j)
    {
        if (_board[i][j] == '*' || word[index] != _board[i][j]) 
            return false;
        
        if (word.Length - 1 == index)
            return true;

        var temp = _board[i][j];
        _board[i][j] = '*';

        foreach (var offset in _offsets)
            if (InBounds(i + offset.Item1, j + offset.Item2))
                if (FindWord(word, index + 1, i + offset.Item1, j + offset.Item2))
                {
                    _board[i][j] = temp;
                    return true;
                }
                
        _board[i][j] = temp;
        return false;
    }

    private bool InBounds(int x, int y)
        => (x >= 0) && (x < _board.Length)
        && (y >= 0) && (y < _board[0].Length);
}
