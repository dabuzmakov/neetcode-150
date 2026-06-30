public class Solution
{
    public int DiameterOfBinaryTree(TreeNode root) {
        var res = 0;
        DFS(root, ref res);
        return res;
    }

    private int DFS(TreeNode root, ref int res) {
        if (root == null) 
            return 0;

        var left = DFS(root.left, ref res);
        var right = DFS(root.right, ref res);

        res = Math.Max(res, left + right);
        
        return 1 + Math.Max(left, right);
    }
}
