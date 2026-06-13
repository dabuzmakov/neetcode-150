public class Solution
{
    public int[] TwoSum(int[] numbers, int target)
    {
        for (var l = 0; l < numbers.Length - 1; l++)
        for (var r = l + 1; r < numbers.Length; r++)
            if (numbers[l] + numbers[r] == target)
                return new int[2] {l + 1, r + 1};
        return [];
    }
}
