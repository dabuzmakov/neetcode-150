public class Solution
{
    public int CanCompleteCircuit(int[] gas, int[] cost)
    {
        if (cost.Sum() > gas.Sum()) 
            return -1;
        
        var result = 0;
        var total = 0;

        for (var i = 0; i < gas.Length; i++)
        {
            total += (gas[i] - cost[i]);

            if (total < 0) 
            {
                total = 0;
                result = i + 1;
            }
        }

        return result;
    }
}
