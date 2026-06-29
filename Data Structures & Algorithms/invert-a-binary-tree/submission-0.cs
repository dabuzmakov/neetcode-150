public class Solution
{
    public TreeNode InvertTree(TreeNode root)
    {
        InvertRecursion(root);
        return root;
    }

    private void InvertRecursion(TreeNode root)
    {
        if (root == null || (root.left == null && root.right == null))
            return;
        
        var dummy = root.left;
        root.left = root.right;
        InvertRecursion(root.left);

        root.right = dummy;
        InvertRecursion(root.right);
    }
}
