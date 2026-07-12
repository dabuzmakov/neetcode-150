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

        var newList = new List<int>(currentNums);
        for (var i = start; i < _nums.Length; i++)
        {
            newList.Add(_nums[i]);
            FindAll(new List<int>(newList), currentSum + _nums[i], i);
            newList.RemoveAt(newList.Count - 1);
        }
    }
}
