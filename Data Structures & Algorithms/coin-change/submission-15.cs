public class Solution
{
    private readonly Dictionary<int, int> _cache = new();

    public int CoinChange(int[] coins, int amount) 
    {
        if (amount == 0) return 0;

        if (_cache.TryGetValue(amount, out var count))
            return count;

        count = int.MaxValue;
        foreach (var coin in coins)
        {
            if (amount - coin < 0) continue;
            var prevCount = CoinChange(coins, amount - coin);
            if (prevCount != -1)
                count = Math.Min(count, 1 + prevCount);
        }

        _cache[amount] = count == int.MaxValue ? -1 : count;;
        return _cache[amount];
    }
}
