public class Solution
{
    public bool IsSameTree(TreeNode p, TreeNode q)
        => p == null && q == null 
            ? true 
            : p?.val == q?.val && IsSameTree(p?.left, q?.left) && IsSameTree(p?.right, q?.right);
}
