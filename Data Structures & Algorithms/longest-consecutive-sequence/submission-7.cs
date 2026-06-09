public class Solution
{
    public int LongestConsecutive(int[] nums) 
    {
        var hash = new HashSet<int>(nums);
        var maxSequence = 0;
        var curSequence = 0;

        foreach (var num in nums)
        {
            if (hash.Contains(num-1))
                continue;
            
            var iterator = num;
            while (hash.Contains(iterator))
            {
                iterator++;
                curSequence++;
            }

            maxSequence = Math.Max(maxSequence, curSequence);
            curSequence = 0;
        }

        return maxSequence;
    }
}
