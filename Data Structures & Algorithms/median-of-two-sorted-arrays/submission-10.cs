public class Solution
{
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        if (nums1.Length > nums2.Length)
            (nums1, nums2) = (nums2, nums1);

        var (lengthA, lengthB) = (nums1.Length, nums2.Length);
        var (left, right) = (0, nums1.Length);
        var partWithMedian = (lengthA + lengthB + 1) / 2;

        while (left <= right)
        {
            var leftPartA = (left + right) / 2;
            var leftPartB = partWithMedian - leftPartA;

            var maxLeftA = leftPartA == 0 ? int.MinValue : nums1[leftPartA - 1];
            var maxLeftB = leftPartB == 0 ? int.MinValue : nums2[leftPartB - 1];
            var minRightA = leftPartA == lengthA ? int.MaxValue : nums1[leftPartA];
            var minRightB = leftPartB == lengthB ? int.MaxValue : nums2[leftPartB];

            if (maxLeftA <= minRightB && maxLeftB <= minRightA)
                return (lengthA + lengthB) % 2 != 0 
                    ? Math.Max(maxLeftA, maxLeftB)
                    : (Math.Max(maxLeftA, maxLeftB) + Math.Min(minRightA, minRightB)) / 2.0;

            if (maxLeftA > minRightB)
                right = leftPartA - 1;
            else left = leftPartA + 1;
        }

        return -1;
    }
}