public class Solution
{
    private static bool _flag = true;

    public bool IsBalanced(TreeNode root)
    {
        var height = GetHeight(root);

        if (_flag == false)
        {
            _flag = true;
            return false;
        }

        return _flag;
    }

    public int GetHeight(TreeNode root)
    {
        if (root == null) return 0;

        var heightLeft = GetHeight(root.left);
        var heightRight = GetHeight(root.right);

        if (Math.Abs(heightLeft - heightRight) > 1)
            _flag = false;

        return 1 + Math.Max(heightLeft, heightRight);
    }
}
