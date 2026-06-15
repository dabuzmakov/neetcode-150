public class Solution
{
    public int Search(int[] nums, int target)
    {
        var left = 0;
        var right = nums.Length;

        while (left < right)
        {
            var middle = left + (right - left) / 2;
            if (nums[middle] == target)
                return middle;
            
            if (nums[middle] < target)
                left = middle + 1;
            else right = middle;
        }

        return -1;
    }
}
