public class Solution
{
    public List<List<int>> ThreeSum(int[] nums)
    {
        Array.Sort(nums);
        var result = new List<List<int>>();
        
        for (var k = 0; k < nums.Length - 2; k++)
        {
            if (k > 0 && nums[k] == nums[k - 1])
                continue;
                
            var left = k + 1;
            var right = nums.Length - 1;

            while (left < right)
            {
                var sum = nums[left] + nums[right] + nums[k];

                if (sum == 0)
                {
                    result.Add(new List<int> { nums[k], nums[left], nums[right] });
                    left++;
                    right--;

                    while (left < right && nums[left - 1] == nums[left]) 
                        left++;
                    while (left < right && nums[right + 1] == nums[right]) 
                        right--;
                }
                else if (sum < 0) left++;
                else right--;
            }
        }

        return result;
    }
}
