public class Solution
{
    public bool IsSameTree(TreeNode p, TreeNode q)
    {
        if (p == null && q == null) 
            return true;

        return p?.val == q?.val && IsSameTree(p?.left, q?.left) && IsSameTree(p?.right, q?.right);
    }

}
