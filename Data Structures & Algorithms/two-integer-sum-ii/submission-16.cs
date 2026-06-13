public class Solution
{
    public int[] TwoSum(int[] numbers, int target)
    {
        var hash = Enumerable
            .Range(0, numbers.Length)
            .ToDictionary(i => numbers[i], i => i);
        
        for (var i = 0; i < numbers.Length - 1; i++)
            if (hash.TryGetValue(target - numbers[i], out var index) && index > i)
                return new int[2] {i + 1, index + 1};
        
        return [];
    }
}
