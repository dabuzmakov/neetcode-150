public class Solution
{
    public int Search(int[] nums, int target)
    {
        var left = 0;
        var right = nums.Length - 1;

        while (left <= right)
        {
            var middle = left + (right - left) / 2;

            if (nums[middle] == target)
                return middle;
            
            if (nums[left] <= nums[middle])
            {
                if (target < nums[middle] && target >= nums[left])
                    right = middle - 1;
                else left = middle + 1;
            }
            else
            {
                if (target > nums[middle] && target <= nums[right])
                    left = middle + 1;
                else right = middle - 1;
            }
        }

        return -1;
    } 
}
