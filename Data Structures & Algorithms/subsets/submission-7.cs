public class Solution
{
    public List<List<int>> Subsets(int[] nums)
    {
        var result = new List<List<int>>();
        result.Add(new List<int>());

        foreach (var num in nums)
        {
            var size = result.Count;

            for (var i = 0; i < size; i++)
            {
                var newList = new List<int>(result[i]);
                newList.Add(num);
                result.Add(newList);
            }
        }

        return result;
    }
}
