public class Solution
{
    public int KthSmallest(TreeNode root, int k)
    {
        var stack = new Stack<TreeNode>();
        var current = root;
        var count = 0;

        while (current != null || stack.Count != 0)
        {
            while (current != null)
            {
                stack.Push(current);
                current = current.left;
            }

            var node = stack.Pop();
            if (++count == k) return node.val;

            current = node.right;
        }

        return -1;
    }
}
