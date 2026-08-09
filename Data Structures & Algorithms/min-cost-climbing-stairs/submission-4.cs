public class Solution
{
    public int MinCostClimbingStairs(int[] cost) 
    {
        var dpTable = new int[cost.Length];
        dpTable[0] = cost[0];
        dpTable[1] = cost[1];
        
        for (var i = 2; i < cost.Length; i++)
            dpTable[i] = Math.Min(dpTable[i - 1], dpTable[i - 2]) + cost[i];

        return Math.Min(dpTable[cost.Length - 1], dpTable[cost.Length - 2]);
    }
}
