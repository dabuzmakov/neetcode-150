public class Solution
{
    public int[] TwoSum(int[] numbers, int target)
    {
        var left = 0;
        var right = numbers.Length - 1;

        while (left < right)
        {
            var first = numbers[left];
            var second = numbers[right];

            if (first + second == target)
                return new int[2] {left + 1, right + 1};
            else if (first + second < target)
                left++;
            else right--;
        }

        return [];
    }
}
