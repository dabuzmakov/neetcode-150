public class Solution
{
    public int Jump(int[] nums)
    {
        var (left, right) = (0, 0);
        var steps = 0;

        while (left < nums.Length - 1 && right < nums.Length - 1)
        {
            var maxStep = 0;
            for (var i = left; i <= right; i++)
                maxStep = Math.Max(i + nums[i], maxStep);

            left = right + 1;
            right = maxStep;
            steps++;
        }

        return steps;
    }
}
