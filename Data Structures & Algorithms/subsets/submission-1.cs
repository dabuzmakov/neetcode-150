public class Solution
{
    private List<List<int>> _result = new();
    private int[] _nums;

    public List<List<int>> Subsets(int[] nums)
    {
        _nums = nums;
        FindAll(new List<int>(), 0);
        return _result;
    }

    public void FindAll(List<int> current, int index)
    {
        if (index == _nums.Length)
        {
            _result.Add(new List<int>(current));
            return;
        }

        current.Add(_nums[index]);

        FindAll(current, index + 1);

        current.RemoveAt(current.Count - 1);

        FindAll(current, index + 1);
    }
}
