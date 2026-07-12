public class Solution
{
    private int[] _nums;
    private int _target;
    private List<List<int>> _result = new();

    public List<List<int>> CombinationSum(int[] nums, int target)
    {
        (_target, _nums) = (target, nums);
        FindAll(new List<int>(), 0, 0);
        return _result;
    }

    private void FindAll(List<int> currentNums, int currentSum, int start)
    {
        if (currentSum > _target) return;

        if (currentSum == _target)
        {
            _result.Add(new List<int>(currentNums));
            return;
        }
        
        for (var i = start; i < _nums.Length; i++)
        {
            currentNums.Add(_nums[i]);
            FindAll(new List<int>(currentNums), currentSum + _nums[i], i);
            currentNums.RemoveAt(currentNums.Count - 1);
        }
    }
}
