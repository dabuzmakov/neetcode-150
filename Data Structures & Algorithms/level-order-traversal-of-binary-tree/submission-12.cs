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
                if (node == null) continue;
                queue.Enqueue(node.left);
                queue.Enqueue(node.right);
                level.Add(node.val);
            }

            if (level.Count() > 0)
                result.Add(level);
        }

        return result;
    }
}
