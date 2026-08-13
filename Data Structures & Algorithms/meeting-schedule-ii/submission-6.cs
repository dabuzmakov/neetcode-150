public class Solution
{
    public int MinMeetingRooms(List<Interval> intervals)
    {
        intervals.Sort((a, b) => a.start.CompareTo(b.start));
        var rooms = new PriorityQueue<Interval, int>();

        foreach (var interval in intervals)
        {
            if (rooms.Count == 0 || rooms.Peek().end > interval.start)
            {
                rooms.Enqueue(interval, interval.end);
                continue;
            }

            rooms.Dequeue();
            rooms.Enqueue(interval, interval.end);
        }

        return rooms.Count;
    }
}
