public class Solution
{
    public List<List<int>> LevelOrder(TreeNode root)
    {
        var result = new List<List<int>>();
        if (root == null) return result;

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count() != 0)
        {
            var level = new List<int>();
            var levelSize = queue.Count(); 

            for (var i = 0; i < levelSize; i++)
            {
                var node = queue.Dequeue();
                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
                level.Add(node.val);
            }

            result.Add(level);
        }

        return result;
    }
}
