public class Solution
{
    public int LongestConsecutive(int[] nums) 
    {
        var hash = new HashSet<int>(nums);
        var maxSequence = 0;

        foreach (var num in nums)
        {
            if (hash.Contains(num-1)) continue;
            
            var curSequence = 0;
            while (hash.Contains(num + curSequence))
                curSequence++;

            maxSequence = Math.Max(maxSequence, curSequence);
        }

        return maxSequence;
    }
}
