public class Solution
{
    public List<List<int>> SubsetsWithDup(int[] nums)
    {
        Array.Sort(nums);
        var result = new List<List<int>>();
        result.Add(new List<int>());
        var lastCount = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            var insertIndex = (i != 0 && nums[i] == nums[i - 1])
                ? lastCount
                : 0;
            
            lastCount = result.Count;
            for (var j = insertIndex; j < lastCount; j++)
            {
                var newSubset = new List<int>(result[j]);
                newSubset.Add(nums[i]);
                result.Add(newSubset);
            }
        }

        return result;
    }
}
