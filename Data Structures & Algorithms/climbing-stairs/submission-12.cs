public class Solution
{
    public int ClimbStairs(int n)
    {     
        if (n <= 2) return n;
        var (prev, cur) = (1, 2);

        for (var i = 3; i < n; i++)
        {
            var temp = prev;
            prev = cur;
            cur = cur + temp;
        }

        return cur + prev;
    }
}
