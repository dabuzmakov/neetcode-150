public class MinStack {

    private readonly Stack<long> _stack;
    private long _min;

    public MinStack()
        => _stack = new Stack<long>();
    
    public void Push(long val)
    {
        if (_stack.Count == 0) _min = val;
        long diff = val - _min;
        _stack.Push(diff);
        if (diff < 0) _min = val;
    }
    
    public void Pop()
    { 
        long head = _stack.Peek();
        if (head < 0) _min -= head;
        _stack.Pop();
    }
    
    public long Top()
    {
        long head = _stack.Peek();
        if (head <= 0) return _min;
        return head + _min;
    }
    
    public long GetMin()
        => _min;
}
