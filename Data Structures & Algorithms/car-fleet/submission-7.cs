public class Solution
{
    public int CarFleet(int target, int[] position, int[] speed)
    {
        var cars = position
            .Zip(speed, (s, v) => (s, t: (double)(target - s) / v))
            .OrderByDescending(car => car.s);
        
        var stack = new Stack<(int s, double t)>();
        
        foreach (var car in cars)
            if (stack.Count == 0 || stack.Peek().t < car.t)
                stack.Push(car);
        
        return stack.Count();
    }
}
