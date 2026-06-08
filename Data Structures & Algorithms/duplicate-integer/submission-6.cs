public class Solution 
{
    public bool hasDuplicate(int[] nums) 
    {
        var setNums = new HashSet<int>();
        
        foreach (var num in nums)
            if (!setNums.Add(num))
                return true;

        return false;
    }
}