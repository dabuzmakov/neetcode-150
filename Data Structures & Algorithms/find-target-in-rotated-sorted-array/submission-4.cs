public class Solution
{
    public int Search(int[] nums, int target)
    {
        var gap = FindGap(nums);
        var findFirst = BinarySearch(nums, target, 0, gap);

        return findFirst == -1 
            ? BinarySearch(nums, target, gap, nums.Length) 
            : findFirst;
    }

    public int FindGap(int[] nums)
    {
        var left = 0;
        var right = nums.Length - 1;

        while (nums[left] > nums[right])
        {
            var middle = left + (right - left) / 2;

            if (nums[middle] > nums[right])
                left = middle + 1;
            else 
                right = middle;
        }

        return left;
    } 

    public int BinarySearch(int[] nums, int target, int left, int right)
    {
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
