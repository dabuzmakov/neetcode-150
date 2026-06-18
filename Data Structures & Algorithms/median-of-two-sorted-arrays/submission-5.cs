public class Solution
{
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        if (nums1.Length > nums2.Length)
            (nums1, nums2) = (nums2, nums1);

        var n = nums1.Length;
        var m = nums2.Length;
        var left = 0;
        var right = n;

        while (left <= right)
        {
            var partitionA = (left + right) / 2;
            var partitionB = (m + n + 1) / 2 - partitionA;

            var maxLeftA  = (partitionA == 0) ? int.MinValue : nums1[partitionA - 1];
            var maxLeftB  = (partitionB == 0) ? int.MinValue : nums2[partitionB - 1];
            var minRightA = (partitionA == n) ? int.MaxValue : nums1[partitionA];
            var minRightB = (partitionB == m) ? int.MaxValue : nums2[partitionB];

            if (maxLeftA <= minRightB && maxLeftB <= minRightA)
                return (m + n) % 2 != 0 
                    ? Math.Max(maxLeftA, maxLeftB)
                    : (Math.Max(maxLeftA, maxLeftB) + Math.Min(minRightA, minRightB)) / 2.0;
            
            if (maxLeftA > minRightB) 
                right = partitionA - 1;
            else left = partitionA + 1;
        }

        return -1;
    }
}
