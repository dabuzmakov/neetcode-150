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
            var level = queue.ToList();
            result.Add(level.Select(x => x.val).ToList());

            while (queue.Count() != 0)
                queue.Dequeue();

            foreach (var node in level)
            {
                if (node.left != null)
                    queue.Enqueue(node.left);
                if (node.right != null)
                    queue.Enqueue(node.right);
            }
        }

        return result;
    }
}
