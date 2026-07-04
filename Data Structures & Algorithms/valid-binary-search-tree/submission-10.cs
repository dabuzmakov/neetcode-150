public class Solution
{
    public bool IsValidBST(TreeNode root)
        => TaskSolver(root, int.MinValue, int.MaxValue);

    public bool TaskSolver(TreeNode root, int min, int max)
    {
        if (root == null) return true;
        
        if ((root.val >= max) || (root.val <= min))
            return false;
        
        return TaskSolver(root.left, min, root.val)
            && TaskSolver(root.right, root.val, max);
    }
}
