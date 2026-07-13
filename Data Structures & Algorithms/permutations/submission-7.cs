public class Solution
{
    private List<List<int>> _result = new();

    public List<List<int>> Permute(int[] nums) 
    {
        FindAll(nums, 0);
        return _result;
    }

    private void FindAll(int[] nums, int index)
    {
        if (index == nums.Length)
        {
            _result.Add(new List<int>(nums));
            return;
        }

        for (var i = index; i < nums.Length; i++)
        {
            (nums[index], nums[i]) = (nums[i], nums[index]);
            FindAll(nums, index + 1);
            (nums[index], nums[i]) = (nums[i], nums[index]);
        }
    }
}
