public class Solution
{
    public int MinEatingSpeed(int[] piles, int h)
    {
        var left = 1;
        var right = piles.Max();

        while (left < right)
        {
            var middle = left + (right - left) / 2;
            var hours = piles
                .Select(x => (int)Math.Ceiling((double)x / middle))
                .Sum();

            if (hours > h)
                left = middle + 1;
            else if (hours <= h)
                right = middle;
        }

        return left;
    }
}
