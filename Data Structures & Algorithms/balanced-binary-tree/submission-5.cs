public class Solution
{
    public bool IsBalanced(TreeNode root)
        => GetHeight(root) != -1;

    public int GetHeight(TreeNode root)
    {
        if (root == null) return 0;

        var heightLeft = GetHeight(root.left);
        if (heightLeft == -1) return -1;

        var heightRight = GetHeight(root.right);
        if (heightRight == -1) return -1;

        return Math.Abs(heightLeft - heightRight) <= 1 
            ? 1 + Math.Max(heightLeft, heightRight)
            : -1;
    }
}
