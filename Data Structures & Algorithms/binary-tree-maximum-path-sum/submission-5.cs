public class Solution
{
    private int _max = int.MinValue;

    public int MaxPathSum(TreeNode root)
    {
        MaxPathSumRecursion(root);
        return _max;
    }

    private int MaxPathSumRecursion(TreeNode root)
    {
        if (root == null) return 0;

        var left = MaxPathSumRecursion(root.left);
        var right = MaxPathSumRecursion(root.right);

        var maxLeft = Math.Max(0, left);
        var maxRight = Math.Max(0, right);

        var currentPathSum = root.val + maxLeft + maxRight;

        _max = Math.Max(_max, currentPathSum);

        return root.val + Math.Max(maxLeft, maxRight);
    }
}
