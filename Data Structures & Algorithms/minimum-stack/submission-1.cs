public class MinStack {

    private readonly Stack<int> _stack;
    private readonly Stack<int> _additionalStack;

    public MinStack()
    {
        _stack = new Stack<int>();
        _additionalStack = new Stack<int>();
    } 
    
    public void Push(int val)
    {
        _stack.Push(val);
        if (_additionalStack.Count == 0 || val <= _additionalStack.Peek())
            _additionalStack.Push(val);
    }
    
    public void Pop()
    { 
        if (_stack.Peek() == _additionalStack.Peek())
            _additionalStack.Pop();
        _stack.Pop();
    }
    
    public int Top()
        => _stack.Peek();
    
    public int GetMin()
        => _additionalStack.Peek();
}
