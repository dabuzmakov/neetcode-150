public class Solution {
    public bool hasDuplicate(int[] nums) {
        var setNums = new HashSet<int>();
        foreach (var num in nums)
        {
            if (setNums.Contains(num))
                return true;
            
            setNums.Add(num);
        }

        return false;
    }
}