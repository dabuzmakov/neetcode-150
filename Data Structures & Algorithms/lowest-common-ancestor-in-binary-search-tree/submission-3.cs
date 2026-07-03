public class Solution
{
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        if  ((q.val > root.val && p.val < root.val) || 
            (q.val < root.val && p.val > root.val) ||
            (root == p || root == q))
        {
            return root;
        }

        return q.val < root.val && p.val < root.val
            ? LowestCommonAncestor(root.left, p, q)
            : LowestCommonAncestor(root.right, p, q);
    }
}
