public class Solution
{
    public TreeNode InvertTree(TreeNode root)
    {
        if (root == null) return null;
        
        var dummy = root.left;
        root.left = root.right;
        root.right = dummy;

        InvertTree(root.left);
        InvertTree(root.right);

        return root;
    }
}
