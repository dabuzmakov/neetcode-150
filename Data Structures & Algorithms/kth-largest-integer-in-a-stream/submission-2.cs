public class KthLargest 
{
    private readonly PriorityQueue<int, int> _queue;
    private readonly int _largestSelector;

    public KthLargest(int k, int[] nums)
    {
        _queue = new PriorityQueue<int, int>();
        _largestSelector = k;

        foreach (var num in nums)
        {
            _queue.Enqueue(num, num);

            if (_queue.Count > _largestSelector)
                _queue.Dequeue();
        }
    }
    
    public int Add(int val) 
    {
        _queue.Enqueue(val, val);
        
        if (_queue.Count > _largestSelector)
            _queue.Dequeue();
        
        return _queue.Peek();
    }
}
