public class Codec
{
    public string Serialize(TreeNode root)
    {
        if (root == null) return "[]";

        var builder = new StringBuilder();
        builder.Append("[");

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count() != 0)
        {
            var node = queue.Dequeue();

            if (node != null)
            {
                builder.Append(node.val).Append(", ");
                queue.Enqueue(node.left);
                queue.Enqueue(node.right);
            }
            else builder.Append("null, ");
        }

        builder.Length -= 2;
        builder.Append("]");
        return builder.ToString();
    }

    public TreeNode Deserialize(string data)
    {
        if (string.IsNullOrEmpty(data) || data == "[]")
            return null;

        var values = data[1..^1].Split(", ");
        var root = new TreeNode(int.Parse(values[0]));
        var queue = new Queue<TreeNode>();
        var pointer = 1;
        queue.Enqueue(root);

        while (queue.Count > 0 && pointer < values.Length)
        {
            var node = queue.Dequeue();

            if (pointer < values.Length)
            {
                var val = values[pointer++];

                if (node != null)
                {
                    node.left = val == "null"
                        ? null
                        : new TreeNode(int.Parse(val));
                    
                    if (node.left != null) 
                        queue.Enqueue(node.left);
                }
            }

            if (pointer < values.Length)
            {
                var val = values[pointer++];

                if (node != null)
                {
                    node.right = val == "null"
                        ? null
                        : new TreeNode(int.Parse(val));
                    
                    if (node.right != null) 
                        queue.Enqueue(node.right);
                }
            }
        }

        return root;
    }
}
