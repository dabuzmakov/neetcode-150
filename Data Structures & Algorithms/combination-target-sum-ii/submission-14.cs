public class Solution
{
    private readonly List<List<int>> _result = new();
    private int[] _candidates;
    private int _target;

    public List<List<int>> CombinationSum2(int[] candidates, int target)
    {
        Array.Sort(candidates);
        (_candidates, _target) = (candidates, target);
        FindAll(new List<int>(), 0, 0);
        return _result;
    }

    public void FindAll(List<int> current, int start, int sum)
    {
        if (_target == sum)
        {
            _result.Add(new List<int>(current));
            return;
        }

        if (sum > _target || start >= _candidates.Length) 
            return;

        for (var i = start; i < _candidates.Length; i++)
        {
            if (sum > _target) break;
            if (i != start && _candidates[i] == _candidates[i - 1])
                continue;

            current.Add(_candidates[i]);
            FindAll(current, i + 1, sum + _candidates[i]);
            current.RemoveAt(current.Count - 1);
        }
    }
}
