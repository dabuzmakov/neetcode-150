public class Solution
{
    private readonly Dictionary<int, int> _cache = new();

    public int CoinChange(int[] coins, int amount) 
    {
        if (amount == 0) return 0;
        if (amount < 0) return -1;

        if (_cache.TryGetValue(amount, out var count))
            return count;

        var options = new List<int>();
        foreach (var coin in coins)
        {
            count = CoinChange(coins, amount - coin);
            if (count != -1) options.Add(1 + count);
        }

        _cache[amount] = options.Count == 0 ? -1 : options.Min();
        return _cache[amount];
    }
}
