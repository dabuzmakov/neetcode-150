public class Solution
{
    public int CarFleet(int target, int[] position, int[] speed)
    {
        var stack = new Stack<double>();
        
        var cars = position
            .Zip(speed, (s, v) => (s, t: (double)(target - s) / v))
            .OrderByDescending(car => car.s);
        
        foreach (var car in cars)
            if (stack.Count == 0 || stack.Peek() < car.t)
                stack.Push(car.t);
        
        return stack.Count();
    }
}
