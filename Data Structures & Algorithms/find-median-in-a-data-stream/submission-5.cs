public class MedianFinder
{
    private readonly PriorityQueue<int, int> _maxHeap = new();
    private readonly PriorityQueue<int, int> _minHeap = new();

    public MedianFinder() {}
    
    public void AddNum(int num)
    {
        _maxHeap.Enqueue(num, -num);
        
        if (_maxHeap.Count - _minHeap.Count > 1)
        {
            var element = _maxHeap.Dequeue();
            _minHeap.Enqueue(element, element);
        }

        if ((_maxHeap.Count > 0 && _minHeap.Count > 0) 
            && _maxHeap.Peek() > _minHeap.Peek())
        {
            var maxElement = _maxHeap.Dequeue();
            var minElement = _minHeap.Dequeue();
            _maxHeap.Enqueue(minElement, -minElement);
            _minHeap.Enqueue(maxElement, maxElement);
        }
    }
    
    public double FindMedian()
    {
        var (biggest, lowest) = _maxHeap.Count > _minHeap.Count 
            ? (_maxHeap, _minHeap)
            : (_minHeap, _maxHeap);

        return (_maxHeap.Count + _minHeap.Count) % 2 == 0 
            ? (_minHeap.Peek() + _maxHeap.Peek()) / 2.0
            : (double)biggest.Peek();
    }
}
