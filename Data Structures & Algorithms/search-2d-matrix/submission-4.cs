public class Solution
{
    public bool SearchMatrix(int[][] matrix, int target)
    {
        var left = 0;
        var right = matrix[0].Length * matrix.Length;

        while (left < right)
        {
            var middle = left + (right - left) / 2;
            var column = middle % matrix[0].Length;
            var row = middle / matrix[0].Length;

            if (matrix[row][column] == target)
                return true;
            
            if (matrix[row][column] < target)
                left = middle + 1;
            else right = middle;
        }

        return false;
    }
}
