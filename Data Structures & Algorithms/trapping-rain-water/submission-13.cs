public class Solution
{
    public int Trap(int[] height)
    {
        var (left, right) = (0, height.Length - 1);
        var (leftMax, rightMax) = (height[left], height[right]);
        var total = 0;

        while (left < right)
        {
            if (leftMax < rightMax)
            {
                left++;
                leftMax = Math.Max(height[left], leftMax); 
                total += leftMax - height[left];
            }
            else
            {
                right--;
                rightMax = Math.Max(height[right], rightMax);
                total += rightMax - height[right];
            }
        }

        return total;
    }
}
