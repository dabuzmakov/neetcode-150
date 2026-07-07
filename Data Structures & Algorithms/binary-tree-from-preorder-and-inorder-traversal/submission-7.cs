public class Solution
{
    public TreeNode BuildTree(int[] preorder, int[] inorder)
    {
        var hash = new Dictionary<int, int>();

        for (var i = 0; i < inorder.Length; i++)
            hash[inorder[i]] = i;

        return BuildTreeRecursion(
            preorder, 0, preorder.Length - 1,
            inorder, 0, inorder.Length - 1,
            hash
        );
    }

    public TreeNode BuildTreeRecursion(
        int[] preorder, int pStart, int pEnd,
        int[] inorder, int iStart, int iEnd,
        Dictionary<int, int> hash)
    {   
        if (pStart > pEnd) return null;

        var element = preorder[pStart];
        var node = new TreeNode(element);
        var leftLength = hash[element] - iStart;
        var rightLength = iEnd - iStart - leftLength;
        
        node.left = leftLength == 0 ? null : BuildTreeRecursion(
            preorder, pStart + 1, pStart + leftLength,
            inorder, iStart, leftLength - 1,
            hash
        );

        node.right = rightLength == 0 ? null : BuildTreeRecursion(
            preorder, pStart + leftLength + 1, pEnd,
            inorder, hash[element] + 1, iEnd,
            hash
        );

        return node;
    }
}
