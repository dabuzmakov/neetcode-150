public class Solution
{
    private readonly Dictionary<int, int> _cache = new() 
    {
        [1] = 1,
        [2] = 2 
    };

    public int ClimbStairs(int n)
    {     
        if (_cache.TryGetValue(n, out var result))
            return result;

        result = ClimbStairs(n - 1) + ClimbStairs(n - 2);
        _cache[n] = result;
        return result;
    }
}
