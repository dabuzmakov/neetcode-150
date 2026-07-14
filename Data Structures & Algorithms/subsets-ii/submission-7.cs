public class Solution
{
    private List<List<int>> _result = new();

    public List<List<int>> SubsetsWithDup(int[] nums)
    {
        Array.Sort(nums);
        FindAll(new List<int>(), 0, nums);
        return _result;
    }

    private void FindAll(List<int> current, int start, int[] nums)
    {
        _result.Add(new List<int>(current));

        for (var i = start; i < nums.Length; i++)
        {
            if (i > start && nums[i] == nums[i - 1])
                continue;
            
            current.Add(nums[i]);
            FindAll(current, i + 1, nums);
            current.RemoveAt(current.Count - 1);
        }
    }
}
