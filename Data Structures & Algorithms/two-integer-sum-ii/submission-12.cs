public class Solution
{
    public int[] TwoSum(int[] numbers, int target)
    {
        for (var i = 0; i < numbers.Length - 1; i++)
            if (TryToSearch(numbers, target - numbers[i], i, out var index))
                return new int[2] {i + 1, index + 1};
        
        return [];
    }

    public bool TryToSearch(int[] numbers, int target, int left, out int middle)
    {
        var right = numbers.Length;
        while (left < right)
        {
            middle = left + (right - left) / 2;
            var pivot = numbers[middle];

            if (pivot == target)
                return true;
            else if (numbers[middle] < target)
                left = middle + 1;
            else right = middle;
        }

        middle = 0;
        return false;
    }
}
