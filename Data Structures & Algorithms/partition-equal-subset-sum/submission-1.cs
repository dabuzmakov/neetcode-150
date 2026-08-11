public class Solution
{
    private readonly Dictionary<(int Index, int Sum), bool> _cache = new();

    public bool CanPartition(int[] nums)
        => nums.Sum() % 2 == 0 && IsPossible(nums, nums.Sum() / 2, 0, 0);

    private bool IsPossible(int[] nums, int target, int index, int sum)
    {
        if (sum == target) return true;
        if (sum > target || index == nums.Length) return false;
        if (_cache.TryGetValue((index, sum), out var res)) return res;
        
        if (!_cache.TryGetValue((index + 1, sum), out var left))
        {
            left = IsPossible(nums, target, index + 1, sum);
            _cache[(index + 1, sum)] = left;
        }
        
        if (!_cache.TryGetValue((index + 1, sum + nums[index]), out var right))
        {
            right = IsPossible(nums, target, index + 1, sum + nums[index]);
            _cache[(index + 1, sum + nums[index])] = right;
        }

        _cache[(index, sum)] = left || right;
        return left || right;
    }
}
