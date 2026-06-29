public class Solution
{
    public int MaxDepth(TreeNode root)
        => root == null 
            ? 0 
            : 1 + Math.Max(MaxDepth(root.left), MaxDepth(root.right));
}
