public class Solution
{    
    public bool IsSubtree(TreeNode root, TreeNode subRoot)
        => root != null && (IsEqual(root, subRoot) || IsSubtree(root?.left, subRoot) || IsSubtree(root?.right, subRoot));

    public bool IsEqual(TreeNode p, TreeNode q)
        => p == null && q == null 
            ? true 
            : p?.val == q?.val && IsEqual(p?.left, q?.left) && IsEqual(p?.right, q?.right);
}
