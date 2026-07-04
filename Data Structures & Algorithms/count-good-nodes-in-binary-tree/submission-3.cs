public class Solution
{
    public int GoodNodes(TreeNode root)
        => FindNodes(root, root.val);

    private int FindNodes(TreeNode node, int maxValue)
    {
        if (node == null) return 0;
        
        if (node.val < maxValue)
            return FindNodes(node.left, maxValue) + FindNodes(node.right, maxValue);
        
        maxValue = node.val;
        return 1 + FindNodes(node.left, maxValue) + FindNodes(node.right, maxValue);
    }
}
