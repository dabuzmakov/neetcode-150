public class Solution
{
    public int MaxProfit(int[] prices)
    {
        var profit = 0;

        for (var i = 0; i < prices.Length - 1; i++)
        for (var j = i + 1; j < prices.Length; j++)
            profit = Math.Max(profit, prices[j] - prices[i]);

        return profit;
    }
}
