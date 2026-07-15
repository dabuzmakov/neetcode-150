public class Solution
{
    private char[][] _board;
    private string _word;

    public bool Exist(char[][] board, string word)
    {
        (_board, _word) = (board, word);

        for (var i = 0; i < board.Length; i++)
        for (var j = 0; j < board[0].Length; j++)
            if (FindWord(i, j, 0)) 
                return true;

        return false;
    }

    private bool FindWord(int i, int j, int index)
    {
        if (!InBounds(i, j) || _board[i][j] == '*' || _word[index] != _board[i][j]) 
            return false;
        
        if (_word.Length - 1 == index)
            return true;

        var temp = _board[i][j];
        _board[i][j] = '*';

        var result = FindWord(i + 1, j, index + 1) ||
                     FindWord(i - 1, j, index + 1) ||
                     FindWord(i, j + 1, index + 1) ||
                     FindWord(i, j - 1, index + 1);

        _board[i][j] = temp;
        return result;
    }

    private bool InBounds(int x, int y)
        => (x >= 0) && (x < _board.Length)
        && (y >= 0) && (y < _board[0].Length);
}
