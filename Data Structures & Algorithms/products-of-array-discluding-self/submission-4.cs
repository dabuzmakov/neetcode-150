public class Solution {
    public int[] ProductExceptSelf(int[] nums) 
    {
        var prefixes = new int[nums.Length];
        var postfixes = new int[nums.Length];
        var output = new int[nums.Length];

        prefixes[0] = 1;
        postfixes[0] = 1;

        for (var i = 1; i < nums.Length; i++)
        {
            prefixes[i] = prefixes[i - 1] * nums[i - 1];
            postfixes[i] = postfixes[i - 1] * nums[^i]; 
        }

        for (var i = 0; i < nums.Length; i++)
            output[i] = prefixes[i] * postfixes[^(i + 1)];

        return output;
    }
}
