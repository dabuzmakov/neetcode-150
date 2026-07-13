public class Solution
{
    private List<List<int>> _result = new();
    private int[] _nums;

    public List<List<int>> Permute(int[] nums) 
    {
        _nums = nums;
        FindAll(new List<int>(), new HashSet<int>());
        return _result;
    }

    private void FindAll(List<int> current, HashSet<int> used)
    {
        if (current.Count == _nums.Length)
        {
            _result.Add(new List<int>(current));
            return;
        }

        foreach (var num in _nums)
        {
            if (used.Contains(num)) continue;
            used.Add(num);

            current.Add(num);
            FindAll(new List<int>(current), new HashSet<int>(used));
            current.RemoveAt(current.Count - 1);
            used.Remove(num);
        }
    }
}
