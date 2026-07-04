public class Solution
{
    public List<int> RightSideView(TreeNode root)
    {
        if (root == null) return [];
        
        var result = new List<int>();
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count() != 0)
        {
            TreeNode node = null;
            var level = queue.Count();

            for (var i = 0; i < level; i++)
            {
                node = queue.Dequeue();
                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
            }

            if (node != null) result.Add(node.val);
        }

        return result;
    }
}
